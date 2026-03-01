using UnityEngine;

public class PointsPlayer : MonoBehaviour
{
    public int points = 0;

    // Changed to OnTriggerEnter2D to detect the ice triggers
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object the player walked through is tagged "Ice"
        if (collision.gameObject.CompareTag("Ice"))
        {
            points++;
            // Debug.Log displays the points in the Console so you can verify it works
            Debug.Log("Current Points: " + points);
        }
    }
}