using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string targetTag = "Enemy";
    public float health = 100;
    bool died = false;

    public GameObject objectToSpawn;

    public Transform target;          // The object to move toward
    public float speed = 5f;          // Movement speed
    public float detectionRange = 3f;
    public float jumpingRange = 3f; // Only move if target is closer than this
    public bool grounded = true;
    public bool canJump = true;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate distance in 2D (ignoring z)
            float distance = Vector2.Distance(transform.position, target.position);
            if(distance < jumpingRange)
            {
                isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
                if (isGrounded & canJump)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);  // reset vertical speed
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }

            if (distance < detectionRange)
            {
                // Move toward target
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    target.position,
                    speed * Time.deltaTime
                );

                
            }
        }
    }

    public void Spawn()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    private void Update()
    {
        if(health <= 0 && died == false)
        {
            died = true;

            gameObject.tag  = "Dead";
            Spawn();

            // Destroy after 5 seconds
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            Destroy(collision.gameObject);
            health -= 20;
        }
    }
}
