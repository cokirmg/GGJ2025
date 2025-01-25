using UnityEngine;

public class Enemy_HorMov : MonoBehaviour
{
    public float speed = 2f;
    public float rayDistance = 1f;
    public float groundRayDistance = 1.5f;
    public LayerMask Obstacle;
    public LayerMask Ground;
    public GameObject Dir;

    private Vector2 direction = Vector2.right;
    private bool isStopped = false;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("andar_anchoa"); 
        }

    }
    void Update()
    {

        if (isStopped) return;


        transform.Translate(direction * speed * Time.deltaTime);

        CheckForObstacles();
    }

    private void CheckForObstacles()
    {

        Debug.DrawRay(Dir.transform.position, direction * rayDistance, Color.red);
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
        
        // Voltear el sprite (opcional)
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bubble"))
        {
            isStopped = true; // Detener al enemigo
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Bubble"))
        {
            isStopped = false;
        }
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    
    //TODO hacer que el enemigo muera
=======
   
>>>>>>> Stashed changes
=======
   
>>>>>>> Stashed changes
}
