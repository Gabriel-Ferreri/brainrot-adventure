using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; // the tip of the player sprite
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    // This variable should represent your player's facing direction
    // 1 = right, -1 = left (for side-scroller)
    public int facingDirection = 1;

    private void Update()
    {
        // Check left mouse click
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Determine shooting direction based on facing
        Vector2 shootDir = new Vector2(facingDirection, 0); // horizontal only

        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Set projectile direction
        projectile.GetComponent<Projectile2D>().Initialize();

        // Optional: rotate projectile to face direction
        if (facingDirection == -1)
            projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    // Call this method when the player flips
    public void Flip(int newFacing)
    {
        facingDirection = newFacing;
    }
}
