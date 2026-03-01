using UnityEngine;

public class Pocion : MonoBehaviour
{
    void Start()
    {
        // Se destruye sola en 5 segundos como medida de seguridad
        Destroy(gameObject, 5f); 
    }

    // Se ejecuta si el Collider de la poción TIENE "Is Trigger" activado
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcesarChoque(collision.gameObject);
    }

    // Se ejecuta si el Collider de la poción NO TIENE "Is Trigger" activado (física real)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcesarChoque(collision.gameObject);
    }

    // Centralizamos la lógica aquí para no repetir código
    void ProcesarChoque(GameObject objetoTocado)
    {
        // 1. IGNORAR AL CIENTÍFICO
        // Volví a agregar tu name.Contains por si tu enemigo no tiene el Tag "Enemy" configurado
        if (objetoTocado.CompareTag("Enemy") || objetoTocado.name.Contains("cientifico"))
        {
            return; // No hace nada, sigue volando
        }

        // 2. DETECTAR AL PINGÜINO
        if (objetoTocado.CompareTag("Player"))
        {
            Debug.Log("¡Le diste al pingüino!");
            // Aquí irá el daño
        }

        // 3. SE DESTRUYE con cualquier otra cosa (Suelo, pared, jugador)
        Destroy(gameObject); 
    }
}