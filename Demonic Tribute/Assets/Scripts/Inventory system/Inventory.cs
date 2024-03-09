using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDragHandler, IDropHandler
{
    //list containing collected items.
    public List<Item> items;

    //reference to item SO
    public Item item;
    public InventoryButton button;
    public GameObject[] invButtons;
    public GameObject mainInvGroup;

    public int itemCount;
    public int maxItemCount;

    public void Start()
    {
        maxItemCount = 17;
     // items = new List<Item>(new Item[17]);
    }

    public void Update()
    {

    }

    public void AddItem(Item item)
    {
        //if (itemCount <= maxItemCount) 
        //{
        //itemCount++;
        Debug.Log(button.btnIndex);
        items.Insert(button.btnIndex, item);
        ListItems();
        //} else if(itemCount >= maxItemCount)
        //{
        //Debug.Log("Max item count reached.");
        //}
    }

    //set item to item that is being added to inventory. for item sprite rendering.
    public void ListItems()
    {
        foreach (GameObject gameObj in invButtons)
        {
            if (gameObj.GetComponent<InventoryButton>().item == null)
            {
                gameObj.GetComponent<InventoryButton>().item = item;
                break;
            }
        }
    }

    public void DelItem(Item item)
    {
        if (itemCount <= 0)
        {
            Debug.Log("Cant delete item. list contains 0 items.");
        }
        else
        {
            items.RemoveAt(button.btnIndex);
            Debug.Log("Item: " + item + "removed.");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Draged object is: " + eventData.selectedObject);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped object was: " + eventData.selectedObject);
        }
    }
}

