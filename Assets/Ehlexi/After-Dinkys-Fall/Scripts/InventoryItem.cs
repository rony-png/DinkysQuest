using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;
    public int quantity;
    public int xpValue;

    public InventoryItem(string name, int quantity, int xpValue)
    {
        this.name = name;
        this.quantity = quantity;
        this.xpValue = xpValue;
    }
}

public class Inventory
{
    private Dictionary<string, InventoryItem> items = new Dictionary<string, InventoryItem>();
    private int maxCapacity;
    private int currentCapacity;
    private int xpValueThreshold;
    private int currentXpValue;
    private int xpValueMultiplier;
    private float timer;
    private float timerDuration;

    public Inventory(int maxCapacity, int xpValueThreshold, int xpValueMultiplier, float timerDuration)
    {
        this.maxCapacity = maxCapacity;
        this.xpValueThreshold = xpValueThreshold;
        this.xpValueMultiplier = xpValueMultiplier;
        this.timerDuration = timerDuration;
    }

    public bool AddItem(string itemName, int quantity, int xpValue)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName].quantity += quantity;
            items[itemName].xpValue += xpValue;
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemName, quantity, xpValue);
            items[itemName] = newItem;
        }

        currentXpValue += quantity * xpValue;

        if (currentXpValue >= xpValueThreshold)
        {
            currentCapacity += xpValueMultiplier;
            currentXpValue = 0;
            Console.WriteLine("Inventory capacity increased to " + currentCapacity);
        }

        if (currentCapacity > maxCapacity)
        {
            currentCapacity = maxCapacity;
            Console.WriteLine("Inventory capacity reached maximum.");
        }

        return true;
    }

    public bool RemoveItem(string itemName, int quantity)
    {
        if (!items.ContainsKey(itemName) || items[itemName].quantity < quantity)
        {
            Console.WriteLine("Item not found in inventory or not enough quantity.");
            return false;
        }

        items[itemName].quantity -= quantity;
        items[itemName].xpValue -= quantity * items[itemName].xpValue;

        if (items[itemName].quantity == 0)
        {
            items.Remove(itemName);
        }

        return true;
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Current inventory:");
        foreach (KeyValuePair<string, InventoryItem> entry in items)
        {
            Console.WriteLine(entry.Value.quantity + "x " + entry.Value.name + " (XP: " + entry.Value.xpValue + ")");
        }
    }

    public void Update(float deltaTime)
    {
        timer += deltaTime;

        if (timer >= timerDuration)
        {
            currentCapacity++;
            Console.WriteLine("Inventory capacity increased to " + currentCapacity);
            timer = 0;
        }

        if (currentCapacity > maxCapacity)
        {
            currentCapacity = maxCapacity;
            Console.WriteLine("Inventory capacity reached maximum.");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Inventory playerInventory = new Inventory(10, 100, 1, 60f);

        playerInventory.AddItem("Potion", 5, 10);
        playerInventory.AddItem("Elixir", 3, 20);
        playerInventory.AddItem("Phoenix Down", 1, 50);
        playerInventory.DisplayInventory();

        playerInventory.RemoveItem("Elixir", 2);
        playerInventory.DisplayInventory();

        float deltaTime = 0.1f;

        while (true)
        {
            playerInventory.Update(deltaTime);
            Console.ReadLine();
        }
    }
}