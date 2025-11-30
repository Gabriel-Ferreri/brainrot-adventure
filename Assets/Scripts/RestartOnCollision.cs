using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartOnCollision : MonoBehaviour
{
    public string deathTag = "Enemy"; // Tag that triggers death
    public string deathSceneName = "Died"; // Name of the death scene
    public string startingSceneName = "Main";
    public float restartDelay = 5f;
    
    public GameObject canvasGameObject;

    public SpriteRenderer spriteRenderer;
    public PlayerShoot playerShoot;
    public PlayerController playerController;
    public CameraFollow cameraFollow;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(deathTag))
        {
            canvasGameObject.SetActive(true);
            spriteRenderer.enabled = false;
            playerShoot.enabled = false;
            playerController.enabled = false;
            cameraFollow.enabled = false;
            StartCoroutine(RestartAfterDelay());
        }
    }

    

    void GoToDeathScene()
    {
        // Load death scene
        SceneManager.LoadScene(deathSceneName);

        // Start restart timer
        StartCoroutine(RestartAfterDelay());
    }

    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);

        // Reload the original level (or main level)
        // Here we assume the first scene in the build settings is the main level
        SceneManager.LoadScene(startingSceneName);
    }
}
