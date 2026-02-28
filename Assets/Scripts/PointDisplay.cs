using UnityEngine;
using TMPro; // Essential for TextMesh Pro components

public class PointDisplay : MonoBehaviour
{
    // Drag your Player object into this slot in the Inspector
    public PointsPlayer playerScript; 
    
    private TextMeshProUGUI textMesh;

    void Start()
    {
        // Automatically finds the Text component on this object
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (playerScript != null)
        {
            // Updates the text to show "Points: " followed by the variable value
            textMesh.text = (playerScript.points * 100).ToString();
        }
    }
}