using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(1); 
    }

    // Por si quieres añadir un botón de "Salir" en tu menú de laboratorio
    public void QuitGame()
    {
        Debug.Log("Saliendo del laboratorio...");
        Application.Quit();
    }
}