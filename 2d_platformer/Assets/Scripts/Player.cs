using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 5f;
    float horizontalValue;
    float verticalValue;
    bool isRunning = false;
    public GroundCheck groundCheck;
    bool facinggRight = false;
    public float runningMultiplier = 1.5f;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    void FixedUpdate()
    {
        Move(horizontalValue);
        Jump();
    }

    void Move(float direction)
    {
        float movement = direction * speed * 40 * Time.deltaTime;
        if (isRunning)
        {
            movement *= runningMultiplier;
        }
        rb.velocity = new Vector2(movement, rb.velocity.y);
        if (movement > 0 && !facinggRight)
        {
            Flip();
        }
        else if (movement < 0 && facinggRight)
        {
            Flip();
        }
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    private void Flip()
    {
        facinggRight = !facinggRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Jump()
    {
        if (verticalValue > 0 && groundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 40 * Time.deltaTime);
        }
    }
}
