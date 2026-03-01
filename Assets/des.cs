using UnityEngine;

public class LogicaPocion : MonoBehaviour 
{
    void Start() {
        // Se destruye sola en 3 segundos por si no toca nada
        Destroy(gameObject, 3f); 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Si toca al Pingüino (asegúrate que el pingüino tenga el Tag "Player")
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("¡PUM!");
        }
        // Se destruye al chocar con CUALQUIER COSA
        Destroy(gameObject); 
    }
}
