using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


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

    private void Start()
    {
        Burpee.GetComponent<GameObject>().SetActive(false);
        //Burpee.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Components"))
        {
            // A�adir el componente recogido
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
        // Destruir los componentes recogidos
        foreach (GameObject cube in Components)
        {
            Destroy(cube);
        }
        Components.Clear();
        Debug.Log("Componentes eliminados.");
    }

    private void StartMouseShake()
    {
        Debug.Log("Mueve el rat�n para instanciar el Burpee.");
        isShaking = true;
        mouseDistance = 0f; // Reiniciar la distancia acumulada
        lastMousePosition = Input.mousePosition; // Registrar posici�n inicial del rat�n
    }

    private void Update()
    {
        if (isShaking)
        {
            // Calcular la distancia acumulada del movimiento del rat�n
            Vector3 currentMousePosition = Input.mousePosition;
            float distance = Vector3.Distance(currentMousePosition, lastMousePosition);

            if (distance > 0.1f)
            {
                mouseDistance += distance;
                Debug.Log($"Distancia acumulada: {mouseDistance}/{shakeThreshold}");
            }

            lastMousePosition = currentMousePosition;

            // Si se supera el umbral, instanciar el Burpee
            if (mouseDistance >= shakeThreshold)
            {
                InstantiateBurpee();
            }
        }
    }

    private void InstantiateBurpee()
    {
        Burpee.GetComponent<GameObject>().SetActive(true);

        //GameObject newBurpee = Instantiate(Burpee, BurpeePosition, Quaternion.Euler(0,0,90));
        Animator burpeeAnimator = Burpee.GetComponent<Animator>();

        if (burpeeAnimator != null)
        {
            // Iniciar la animaci�n de nacimiento
            StartCoroutine(PlayBirthAnimation(burpeeAnimator));
        }

        Debug.Log("BURPEEEE creado.");
        isShaking = false;
    }

    private System.Collections.IEnumerator PlayBirthAnimation(Animator burpeeAnimator)
    {
        yield return new WaitForSeconds(0.5f);

        burpeeAnimator.SetTrigger("Birth");
       
        float wait = burpeeAnimator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log(wait);
        yield return new WaitForSeconds(wait);
        
      
        SceneManager.LoadScene("Level_1");
    }
}
