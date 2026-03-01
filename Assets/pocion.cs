using UnityEngine;

public class Pocion : MonoBehaviour
{
    void Start()
    {
        // Se destruye sola en 5 segundos para no llenar el mapa de basura
        Destroy(gameObject, 5f); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. IGNORAR AL CIENTÍFICO (Para que no explote en su mano)
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.name.Contains("cientifico"))
        {
            return; // No hace nada y sigue su camino
        }

        // 2. DETECTAR AL PINGÜINO
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Le diste al pingüino!");
            // Aquí puedes poner el código de daño
        }

        // 3. SE DESTRUYE con cualquier otra cosa (suelo o pared)
        Destroy(gameObject); 
    }
}