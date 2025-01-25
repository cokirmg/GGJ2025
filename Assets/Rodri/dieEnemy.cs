using System;
using UnityEngine;

public class dieEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "EnemyBubble")
        {
            spawnObject.GetComponent<Spawner>().SpawnEnemies();
            Destroy(other.gameObject);
        }
    }
}
