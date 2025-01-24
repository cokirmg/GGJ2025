using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private GameObject _spawnPoint;
    private Rigidbody2D _rb2d;

    private float _shootCooldown = 0.5f;
    private bool _canShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _projectile && _canShoot)
        {
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
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //Ataque hacia izquierda
            scriptProjectile.rightShoot = false;
        }
        Instantiate(_projectile, _spawnPoint.transform.position, Quaternion.identity);
        StartCoroutine(shootCoroutine());
    }

    IEnumerator shootCoroutine()
    {
        if (_canShoot)
        {
            _canShoot = false;
            yield return new WaitForSeconds(_shootCooldown);
            _canShoot = true;
        }
    }
    
}
