using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaypointEnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private List<GameObject> waypointList;

    [SerializeField]
    private float waypointThreshold = 0.5f;

    private Vector3 actualWaypoint;
    private int waypointIndex = 0;
    private bool goingBack = false;

    private bool isStopped = false;
    
    private void Start()
    {
        actualWaypoint = waypointList[0].transform.position;
        transform.position = actualWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped) return;

        Vector3 direction = actualWaypoint - transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        //Hemos llegado a nuestro destino, actualizémoslo 
        if (Vector3.Distance(transform.position, actualWaypoint) < waypointThreshold)
        {
            //Si hemos llegado al máximo de la lista 

            if(waypointIndex + 1 >= waypointList.Count)
                goingBack = true;
            else if(waypointIndex <= 0)
                goingBack = false;

            if (goingBack)
                waypointIndex--;
            else
                waypointIndex++;

            actualWaypoint = waypointList[waypointIndex].transform.position;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (var waypoint in waypointList)
        {
            Gizmos.DrawSphere(waypoint.transform.position, 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))
        {
            Debug.Log("Colision con burbuja");
            isStopped = true; // Detener al enemigo
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Bubble"))
        {
            //isStopped = false;
        }
    }
}
