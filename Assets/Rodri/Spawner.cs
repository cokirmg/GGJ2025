using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;

    void Start()
    {
        //SpawnEnemies();
        Instantiate(enemyObject, transform.position, Quaternion.identity);
    }
    public void SpawnEnemies()
    {
        StartCoroutine((spawnEnemiesCoroutine()));
    }

    IEnumerator spawnEnemiesCoroutine()
    {
        
        yield return new WaitForSeconds(1f);
        Instantiate(enemyObject, transform.position, Quaternion.identity);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "EnemyBubble")
        {
            SpawnEnemies();
            Destroy(other.gameObject);
        }
    }
}
