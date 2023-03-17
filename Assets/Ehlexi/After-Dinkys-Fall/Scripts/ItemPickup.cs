using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public int xpValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory playerInventory = collision.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(itemName, quantity, xpValue);
                Destroy(gameObject);
            }
        }
    }
}

