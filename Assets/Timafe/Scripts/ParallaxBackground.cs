using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 0.5f; // the speed at which the background moves
    public Transform playerTransform; // the player's transform

    private Vector3 lastPlayerPosition; // the player's last position

    private void Start()
    {
        lastPlayerPosition = playerTransform.position;
    }

    private void FixedUpdate()
    {
        // calculate the distance the player has moved since the last frame
        float distanceMoved = playerTransform.position.x - lastPlayerPosition.x;

        // calculate the new position for the background based on the distance moved and the speed
        Vector3 newPosition = transform.position + new Vector3(distanceMoved * speed, 0, 0);

        // update the position of the background
        transform.position = newPosition;

        // update the lastPlayerPosition to the current position
        lastPlayerPosition = playerTransform.position;
    }
}
