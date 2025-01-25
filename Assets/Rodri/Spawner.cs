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
        
        
    }
}
