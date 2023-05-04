using UnityEngine;

public class MovementLock : MonoBehaviour
{
    public float cameraSpeed = 1.0f;
    private bool isColliding = false;
    private GameObject player;
    private Rigidbody2D playerRigidbody;
    private Vector3 cameraStartPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        cameraStartPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Set the flag to indicate the player is colliding with this trigger
            isColliding = true;

            // Lock the player's movement
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the flag when the player leaves the trigger
            isColliding = false;

            // Unlock the player's movement
            playerRigidbody.constraints = RigidbodyConstraints2D.None;
        }
    }

    void LateUpdate()
    {
        // If the player is colliding with the trigger, move the camera to the right slowly
        if (isColliding)
        {
            Vector3 cameraPosition = transform.position;
            float newPositionX = Mathf.Lerp(cameraPosition.x, cameraStartPosition.x + 10.0f, cameraSpeed * Time.deltaTime);
            transform.position = new Vector3(newPositionX, cameraPosition.y, cameraPosition.z);
        }
    }
}
