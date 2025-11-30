using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject canvasObject; // assign your canvas here
    public string targetTag = "Player"; // tag that should trigger the canvas

    public SpriteRenderer spriteRenderer;
    public PlayerShoot playerShoot;
    public PlayerController playerController;
    public CameraFollow cameraFollow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            spriteRenderer.enabled = false;
            playerShoot.enabled = false;
            playerController.enabled = false;
            cameraFollow.enabled = false;
            canvasObject.SetActive(true);
        }
    }
    
}
