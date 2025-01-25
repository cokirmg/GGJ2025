using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Minigame_Manager : MonoBehaviour
{
    public Transform GastricAcid;              
    public GameObject Burpee;         
    public Vector3 BurpeePosition;       

    private List<GameObject> Components = new List<GameObject>(); 
    private bool isShaking = false;      
    private float shakeThreshold = 6000f;   
    private float mouseDistance = 0f;      
    private Vector3 lastMousePosition;    

    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.CompareTag("Components"))
        {
            Components.Add(other.gameObject);

            if (Components.Count == 5 && !isShaking)
            {
                DestroyComponents();
                StartMouseShake();
            }
        }
    }

    private void DestroyComponents()
    {
       
        foreach (GameObject cube in Components)
        {
            Destroy(cube);
        }
        Components.Clear();
        Debug.Log("Components eliminados.");
    }

    private void StartMouseShake()
    {
        Debug.Log("Mueve el ratón a lo loco para instanciar el nuevo cubo.");
        isShaking = true;
        mouseDistance = 0f; // Reiniciar la distancia acumulada del ratón
        lastMousePosition = Input.mousePosition; // Registrar la posición inicial del ratón
    }

    private void Update()
    {
        if (isShaking)
        {
            Vector3 currentMousePosition = Input.mousePosition;

            // Calcular la distancia entre la posición actual y la última
            float distance = Vector3.Distance(currentMousePosition, lastMousePosition);

            if (distance > 0.1f) 
            {
                mouseDistance += distance;
                Debug.Log($"Distancia acumulada: {mouseDistance}/{shakeThreshold}");
            }

            // Actualizar la última posición del ratón
            lastMousePosition = currentMousePosition;

            // Verificar si la distancia acumulada es suficiente
            if (mouseDistance >= shakeThreshold)
            {
               
                InstantiateBurpee();
            }
        }
    }

    private void InstantiateBurpee()
    {
        Instantiate(Burpee, BurpeePosition, Quaternion.identity);
        Debug.Log("BURPEEEE");
        isShaking = false;
    }
}
