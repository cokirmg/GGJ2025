using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagert : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        nextScene();
    }

    void nextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
