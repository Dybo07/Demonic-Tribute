using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameItem : MonoBehaviour
{
    public Item item;

    public GameObject playerInventory;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player")) 
        {
            Debug.Log("item collided with player.");
            //FindObjectOfType<Inventory>().items.Add(item.id, item.itemWeigth);
            playerInventory.GetComponent<Inventory>().items.Add(item.id, item.itemWeigth);
            //Debug.Log(inventory.GetComponent<Inventory>().items);
        }
    }
}
