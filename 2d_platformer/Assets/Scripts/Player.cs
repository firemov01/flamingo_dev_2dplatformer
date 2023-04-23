using System.Collections;
using System.Collections.Generic;
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
    public CapsuleCollider2D capsuleCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
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
            movement *= 2;
        }
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    void Jump()
    {
        if (verticalValue > 0 && groundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 40 * Time.deltaTime);
        }
    }
}
