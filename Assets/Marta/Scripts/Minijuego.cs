using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class Minijuego : MonoBehaviour
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
        
        Burpee.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Components"))
        {
          
            if (!Components.Contains(other.gameObject))
            {
                Components.Add(other.gameObject);
                StartCoroutine(DestroyAfterDelay(other.gameObject, 5f));
            }

 
            if (Components.Count == 5 && !isShaking)
            {
                StartMouseShake();
            }
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject component, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (component != null) 
        {
            Components.Remove(component); // Elimina de la lista antes de destruir
            Destroy(component);
            Debug.Log($"Componente {component.name} destruido después de {delay} segundos.");
        }
    }


    private void StartMouseShake()
    {
        Debug.Log("Mueve el ratón para instanciar el Burpee.");
        isShaking = true;
        mouseDistance = 0f;
        lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (isShaking)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float distance = Vector3.Distance(currentMousePosition, lastMousePosition);

            if (distance > 0.1f)
            {
                mouseDistance += distance;
                Debug.Log($"Distancia acumulada: {mouseDistance}/{shakeThreshold}");
            }

            lastMousePosition = currentMousePosition;

            if (mouseDistance >= shakeThreshold)
            {
                InstantiateBurpee();
            }
        }
    }

    private void InstantiateBurpee()
    {
        Burpee.SetActive(true);

        Animator burpeeAnimator = Burpee.GetComponent<Animator>();
        if (burpeeAnimator != null)
        {
            StartCoroutine(PlayBurpeeAnimations(burpeeAnimator));
        }

        Debug.Log("BURPEEEE creado.");
        isShaking = false;
    }

    private IEnumerator PlayBurpeeAnimations(Animator burpeeAnimator)
    {
        burpeeAnimator.SetTrigger("Idle");
        yield return new WaitForSeconds(1.5f); // Duración de la animación "Idle"

        burpeeAnimator.SetTrigger("Birth");
        yield return new WaitForSeconds(10f); // Duración de la animación "Birth"

        Debug.Log("Cambiando a la escena 'Lvl_1'...");
        SceneManager.LoadScene("Lvl_1");
    }
}
