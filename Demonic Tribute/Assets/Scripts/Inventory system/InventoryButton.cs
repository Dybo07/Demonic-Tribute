using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public GameObject inventory;
    public void OnPointerClick(PointerEventData eventData)
    {
        AddItem();
    }

    public void AddItem() 
    {
        Debug.Log("Added item");
        inventory.GetComponent<Inventory>().items.Add(item);
        Debug.Log(inventory.GetComponent<Inventory>().items.Count);
    }
}
