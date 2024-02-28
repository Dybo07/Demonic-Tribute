using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public void OnPointerClick(PointerEventData eventData)
    {
        AddItem();
    }

    public void AddItem() 
    {
        Debug.Log("Added item");
    }
}
