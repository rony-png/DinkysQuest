using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Singleton instance
    public static InventoryManager instance;

    // List of items in inventory
    public List<Item> items = new List<Item>();

    // UI elements
    public Transform itemContent;
    public GameObject inventoryItemPrefab;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Set the singleton instance
        instance = this;
    }

    // Add an item to the inventory
    public void Add(Item item)
    {
        // Add the item to the list
        items.Add(item);

        // Update the UI
        UpdateUI();
    }

    // Remove an item from the inventory
    public void Remove(Item item)
    {
        // Remove the item from the list
        items.Remove(item);

        // Update the UI
        UpdateUI();
    }

    // Update the UI to show the current inventory items
    public void UpdateUI()
    {
        // Clear the existing UI items
        foreach (Transform child in itemContent)
        {
            Destroy(child.gameObject);
        }

        // Create a new UI item for each inventory item
        foreach (var item in items)
        {
            // Create a new UI item prefab
            GameObject newItem = Instantiate(inventoryItemPrefab, itemContent);

            // Set the UI item's name and icon
            var itemName = newItem.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = newItem.transform.Find("ItemIcon").GetComponent<Image>();
            itemName.text = item.ItemName;
            itemIcon.sprite = item.icon;
        }
    }
}
