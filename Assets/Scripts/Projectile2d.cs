using UnityEngine;

public class Projectile2D : MonoBehaviour
{

   public float speed = 10f;       // Movement speed
    public float lifetime = 3f;     // Destroy after X seconds

    private bool moveRight = true;  // True = right, False = left

   

    private void Start()
    {
        Destroy(gameObject, lifetime); // Auto-destroy after lifetime
    }

    // Call this immediately after instantiating the projectile
    public void Initialize()
    {
        

    }

    private void Update()
    {
        Vector2 direction = Vector2.right;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    
}
