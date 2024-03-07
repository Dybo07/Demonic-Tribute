using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Inventory inventory;
    public Item item;
    public int btnIndex;

    //public Sprite itemSprite;
    //public Sprite slotImage;
    //public Sprite defaultSprite;

    public bool isClicked = false;
    public void Start()
    {
        //defaultSprite = slotImage;
        //itemSprite = item.icon;
    }

    public int buttonIndex() 
    {
        return btnIndex;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (isClicked == false)
        {
            inventory.AddItem(item);
            //idfk
            //slotImage = itemSprite;
            //gameObject.GetComponent<RawImage>().texture = slotImage;
            isClicked = !isClicked;
        }
        else if (isClicked == true) 
        {
            inventory.DelItem(item);
            //idfk
            //slotImage = defaultSprite;
            isClicked = !isClicked;
        }
        
    }
}
