using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    
    public float delayTime = 0.3f; 
    
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // SmoothDamp creates a much better delayed "spring" effect than Lerp
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, delayTime);
    }
}