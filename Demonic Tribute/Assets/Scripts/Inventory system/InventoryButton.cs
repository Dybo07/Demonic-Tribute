using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryButton : MonoBehaviour, IPointerClickHandler, IDragHandler, IDropHandler
{
    public Inventory inventory;
    public Item item;
    public int btnIndex;
    public bool isClicked = false;
    public RawImage itemSprite;

    public void Update()
    {
        if (item != null)
        {
            itemSprite.gameObject.SetActive(true);
            itemSprite.texture = item.icon.texture;
        }
        else if (item == null)
        {
            itemSprite.gameObject.SetActive(false);
            itemSprite.texture = null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClicked == false)
        {
            inventory.AddItem(item);
            isClicked = !isClicked;
        }
        else if (isClicked == true)
        {
            inventory.DelItem(item);
            isClicked = !isClicked;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) 
        {
            Debug.Log("Bababooey");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Event.current != null)
        {
            Debug.Log("Bababooey");
        }
    }
}
