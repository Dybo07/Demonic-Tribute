using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Container : MonoBehaviour
{

    public Inventory playerinv;
    public Item item;
    
    public void AddItem(Item item) 
    {
        playerinv.items.Add(item);
    }
}
