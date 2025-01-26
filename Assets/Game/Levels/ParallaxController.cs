using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D player;

    [SerializeField]
    private List<Transform> backgroundLayers;

    private List<float> ZPositions = new List<float>();

    public float movementVelocity = 0.5f;

    public float movemementDecrease = 0.2f;

    public void Start()
    {
        for (int i = 0; i < backgroundLayers.Count; i++)
        {
            ZPositions.Add(backgroundLayers[i].position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgroundLayers.Count; i++)
        {
            backgroundLayers[i].Translate(
                (-player.linearVelocity.x * movementVelocity * Time.deltaTime) / (movemementDecrease * i + 1), 
                (-player.linearVelocity.y * movementVelocity * Time.deltaTime) / (movemementDecrease * i + 1),
                0);
        }
    }
}
