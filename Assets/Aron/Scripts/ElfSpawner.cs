using UnityEngine;

public class ElfSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn when the collider is triggered

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Replace "Player" with the tag of the object that should trigger the spawn
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
