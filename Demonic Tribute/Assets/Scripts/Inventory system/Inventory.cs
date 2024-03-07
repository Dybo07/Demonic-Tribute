using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(18);

    public Item item;
    public InventoryButton button;

    public int itemCount;
    public int maxItemCount;

    public void Start()
    {
        maxItemCount = 17;
    }

    public void AddItem(Item item)
    {
        if (itemCount <= maxItemCount) 
        {
            itemCount++;
            items.Insert(button.btnIndex, item);
        } else if(itemCount >= maxItemCount)
        {
            Debug.Log("Max item count reached.");
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

}

