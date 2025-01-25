using System;
using UnityEngine;

public class dieEnemy : MonoBehaviour
{
    private GameObject spawnObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnObject = GameObject.FindGameObjectWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "die")
        {
            spawnObject.GetComponent<Spawner>().SpawnEnemies();
            Destroy(this.gameObject);
        }
    }
}
