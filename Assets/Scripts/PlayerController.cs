using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public bool isFacingRight = false;
    float horizontal = 0.0f;

    public float jumpForce = 7f;
    public float speed = 0.025f;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Jump when pressing space
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);  // reset vertical speed
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        
    }
    void FixedUpdate()
    {
        if(Keyboard.current.aKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            horizontal = 1.0f;
        }
        else
        {
            horizontal = 0f;
        }
        

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal;
        transform.position = position;
        
        flip();
    }

    void flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
