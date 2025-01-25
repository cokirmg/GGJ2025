using UnityEngine;

public class Enemy_HorMov : MonoBehaviour
{
    public float speed = 2f;
    public float rayDistance = 1f;
    public float groundRayDistance = 1.5f;
    public LayerMask Obstacle;
    public LayerMask Ground;

    private Vector2 direction = Vector2.right;
    private bool isStopped = false;
    public GameObject dir;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("Andar", false); 
        }
    }

    void Update()
    {
        if (isStopped)
        {
            
            UpdateAnimation(false);
            return;
        }


        transform.Translate(direction * speed * Time.deltaTime);
        UpdateAnimation(true);

        CheckForObstacles();
    }

    private void CheckForObstacles()
    {

        Debug.DrawRay(dir.transform.position, direction * rayDistance, Color.red);
        Debug.DrawRay(transform.position + Vector3.down * 0.5f, Vector2.down * groundRayDistance, Color.blue); 

        RaycastHit2D wallHit = Physics2D.Raycast(transform.position, direction, rayDistance, Obstacle);


        RaycastHit2D groundHit = Physics2D.Raycast(transform.position + Vector3.down * 0.5f, Vector2.down, groundRayDistance, Ground);


        if (wallHit.collider != null || groundHit.collider == null)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {

        direction = -direction;

 
        Vector3 scale = transform.localScale;
        scale.x = direction.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bubble"))
        {
            isStopped = true;
            UpdateAnimation(false); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Bubble"))
        {
            isStopped = false;
            UpdateAnimation(true);
        }
    }
    private void UpdateAnimation(bool isWalking)
    {
        if (animator != null)
        {
            animator.SetBool("Andar", isWalking);
        }
    }


    //TODO hacer que el enemigo muera
}
