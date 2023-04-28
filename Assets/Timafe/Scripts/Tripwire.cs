using UnityEngine;

public class Tripwire : MonoBehaviour
{
    // The prefab that will be instantiated when the player collides with this sprite
    public GameObject prefab;

    // The transform of the sprite where the prefab will be instantiated
    public Transform spawnPoint;

    // A flag to track whether the Tripwire has already been triggered
    private bool triggered = false;

    // Called when a collider enters the trigger zone of this sprite
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player and the Tripwire hasn't been triggered yet
        if (other.CompareTag("Player") && !triggered)
        {
            // Set the triggered flag to true
            triggered = true;

            // Instantiate the prefab at the specified position
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
