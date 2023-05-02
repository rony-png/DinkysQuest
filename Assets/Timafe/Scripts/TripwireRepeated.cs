using UnityEngine;

public class TripwireRepeated : MonoBehaviour
{
    // The prefab that will be instantiated when the player collides with this sprite
    public GameObject prefab;

    // The transform of the sprite where the prefab will be instantiated
    public Transform spawnPoint;

    // Called when a collider enters the trigger zone of this sprite
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Instantiate the prefab at the specified position
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
