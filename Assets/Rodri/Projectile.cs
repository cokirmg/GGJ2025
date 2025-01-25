using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool rightShoot = true;
    [SerializeField]
    private float _projectileSpeed = 20f;
    [SerializeField]
    private float _enemyGravity = -3f;
    
    private Rigidbody2D _rb2d;
    
    //TODO que la bala dure cierto tiempo
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = _enemyGravity;
            other.gameObject.tag = "EnemyBubble";
            Debug.Log(other.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
