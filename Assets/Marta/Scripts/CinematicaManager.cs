using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicaManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Arrastra el componente Video Player en el inspector.
    public string escenaSiguiente; // Nombre de la escena a cargar.

    void Start()
    {
        // Subscribirse al evento que se llama cuando termina el video.
        videoPlayer.loopPointReached += TerminarVideo;
    }

    void TerminarVideo(VideoPlayer vp)
    {
        // Cargar la siguiente escena.
        SceneManager.LoadScene(escenaSiguiente);
    }
}
