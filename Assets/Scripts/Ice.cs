using UnityEngine;

public class Ice : MonoBehaviour
{
    // OnTriggerEnter2D allows the player to pass through
    void OnTriggerEnter2D(Collider2D other) 
    {
        // "other" is the Collider that entered the ice
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}