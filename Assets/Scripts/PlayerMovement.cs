using UnityEngine;

public class PlayerMovemente : MonoBehaviour
{
    public float speed = 5.0f;
    public float minspeed = 5.0f;
    public float maxspeed = 10.0f;

    private float movementX;

    private Rigidbody2D rb;
    public float jumpForce = 10.0f;

    public bool isColliding = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
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

}
