using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item item;

    // Use this method to initialize the item properties when the object is created
    public void Initialize(Item item)
    {
        this.item = item;
        // Do any other initialization logic here
    }

    // Start is called before the first frame update
    void Start()
    {
        // Use the item properties to update the game object
        GetComponent<SpriteRenderer>().sprite = item.icon;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
