using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerBehaviour : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private GameObject _spawnPoint;
    [SerializeField]
    private GameObject _projectileSpawnPoint;
    private Rigidbody2D _rb2d;

    private float _shootCooldown = 0.5f;
    private bool _canShoot = true;
    private Animator anim;
    [SerializeField]
    private Animator dieAnimator;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _projectile && _canShoot)
        {
            anim.SetTrigger("Attack");
            Shoot();
        }
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        Projectile scriptProjectile = _projectile.GetComponent<Projectile>();
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Ataque hacia derecha
            scriptProjectile.rightShoot = true;

        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            //Ataque hacia izquierda
            scriptProjectile.rightShoot = false;
        }
        
        StartCoroutine(shootCoroutine());
    }

    IEnumerator shootCoroutine()
    {
        if (_canShoot)
        {
            _canShoot = false;
            yield return new WaitForSeconds(0.3f);
            Instantiate(_projectile, _projectileSpawnPoint.transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(_shootCooldown);
            _canShoot = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetDamage();
        }
    }
    void GetDamage()
    {
        //TODO maybe una corrutina de muerte y luego este spawn, esto temporal
        this.transform.position = _spawnPoint.transform.position;
    }

    IEnumerator DamageCoroutine()
    {
        
        yield return new WaitForSeconds(0.3f);
        GetDamage();
    }
}
