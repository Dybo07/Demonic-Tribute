using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Inventory inventory;
    public Item item;
    public void Start()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Bababooey");
        inventory.AddItem(item);
    }
}
