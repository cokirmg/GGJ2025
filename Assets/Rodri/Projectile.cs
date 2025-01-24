using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool rightShoot = true;
    private float _projectileSpeed = 50f;
    private float _enemyGravity = -0.5f;
    
    private Rigidbody2D _rb2d;
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
            //TODO Que el enemigo flote
            
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = _enemyGravity;
            Destroy(this.gameObject);
        }
    }
}
