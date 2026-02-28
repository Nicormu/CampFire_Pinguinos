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

    public bool isColliding = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Platform")
            {
                isColliding = true;
            }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isColliding = false;
        }
    }

    void Jump()
    {
        if (isColliding)
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

}
