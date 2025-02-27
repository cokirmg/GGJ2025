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
        // Asegúrate de que Burpee esté inicialmente desactivado
        Burpee.SetActive(false);
    }

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
        Debug.Log("Componentes eliminados.");
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
        // Comienza con la animación de "Idle"
        burpeeAnimator.SetTrigger("Idle");

        // Esperar a que termine la animación "Idle"
        yield return new WaitForSeconds(burpeeAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Activar la animación de "Birth"
        burpeeAnimator.SetTrigger("Birth");

        // Esperar a que termine la animación "Birth"
        float birthAnimationTime = burpeeAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(birthAnimationTime);

        // Cambiar a la escena del nivel 1
        SceneManager.LoadScene("Level_1");
    }
}
