using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int itemWeight = 1;
    public string itemType = "test_item";
    public string itemName = "test_item";
    public GameObject inventory;

    public void Start()
    {
        inventory.GetComponent<Inventory>();
    }

    public void AddItemToInventory() 
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            //add item as inventory item to inventory en destroy item
            Debug.Log(itemName + " Collided with player");
            AddItemToInventory();
        }
    }
}
