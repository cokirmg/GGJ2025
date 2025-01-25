using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool rightShoot = true;
    [SerializeField]
    private float _projectileSpeed = 20f;

    [SerializeField]
    private float _enemyGravity = -3f;
    
    private CircleCollider2D _circleCollider2D;
    private BoxCollider2D _boxCollider2D;
    
    private Rigidbody2D _rb2d;
    
    private Vector2 directionRight = Vector2.right;
    private Vector2 directionLeft = Vector2.left;
    private float rayDistance = 1f;
    private LayerMask Obstacle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rightShoot)
        {
            _rb2d.transform.Translate(new Vector2(_projectileSpeed * Time.deltaTime, 0));
        }
        else
        {
            _rb2d.transform.Translate(new Vector2(-_projectileSpeed * Time.deltaTime, 0));
        }
        
        RaycastHit2D wallHitRight = Physics2D.Raycast(transform.position, directionRight, rayDistance, Obstacle);
        RaycastHit2D wallHitLeft = Physics2D.Raycast(transform.position, directionRight, rayDistance, Obstacle);
        if (wallHitRight.collider != null || wallHitLeft.collider != null)
        {
            enemyWallHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = _enemyGravity;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            other.gameObject.tag = "EnemyBubble";
            Debug.Log(other.gameObject.tag);
            Destroy(this.gameObject);
        }

        
    }

    void enemyWallHit()
    {
        
    }
}
