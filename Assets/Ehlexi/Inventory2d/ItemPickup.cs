using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    // Call this method to add the item to the inventory and destroy the game object
    void Pickup()
    {
        InventoryManager.instance.Add(item);
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Pickup();
        }
    }
}
