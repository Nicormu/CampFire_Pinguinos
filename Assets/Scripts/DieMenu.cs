using UnityEngine;
using UnityEngine.SceneManagement; 

public class DieMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void QuitGame()
    {
        Debug.Log("Saliendo del laboratorio...");
        Application.Quit();
    }
}
