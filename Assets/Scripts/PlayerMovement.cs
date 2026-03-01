using UnityEngine;

public class PlayerMovemente : MonoBehaviour
{
    public float speed = 5.0f;
    public float minspeed = 5.0f;
    public float maxspeed = 10.0f;

    private float movementX;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    public float jumpForce = 10.0f;

    [Header("Grounded Settings")]
    public Transform groundCheck;      // Create an empty child at penguin's feet and drag it here
    public float checkRadius = 0.2f;   // Small circle size
    public LayerMask groundLayer;      // Set this to the layer your Tilemap is on
    private bool isGrounded;           // Replaces isColliding for jumping logic

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the feet are touching the ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        movementX = Input.GetAxisRaw("Horizontal");

        if (movementX < 0)
        {
            sr.flipX = true;
        }
        else if (movementX > 0)
        {
            sr.flipX = false;
        }

        AnimatorManager();
        Sprint();
        
        rb.linearVelocity = new Vector2(movementX * speed, rb.linearVelocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Now it only jumps if the groundCheck is actually touching the floor
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    float Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = maxspeed;
        }
        else
        {
            speed = minspeed;
        }
        return speed;
    }

    void AnimatorManager()
    {
        if (movementX == 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
        else if (movementX != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }
    }
    
    // Draw the circle in the editor so you can see where the "feet" are
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}