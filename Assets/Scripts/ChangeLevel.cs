using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. Verificamos que SOLO el jugador (tu pingüino) pueda cambiar de nivel
        if (collision.gameObject.CompareTag("Player"))
        {
            // 2. Obtenemos el índice de la escena actual
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            
            // 3. Cargamos el siguiente nivel
            SceneManager.LoadScene(nivelActual + 1);
        }
    }
}