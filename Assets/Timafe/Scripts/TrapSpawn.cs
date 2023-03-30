using UnityEngine;

public class TrapSpawn : MonoBehaviour
{
    public GameObject trapPrefab;   // the prefab of the trap to be spawned
    public Transform spawnLocation; // the location where the trap will be spawned

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the trigger has been collided with by the player
        if (other.gameObject.CompareTag("Player"))
        {
            // spawn the trap at the specified location
            Instantiate(trapPrefab, spawnLocation.position, Quaternion.identity);
        }
    }
}