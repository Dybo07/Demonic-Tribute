using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public InvManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickUpItem(int id) 
    {
        inventoryManager.AddItem(itemsToPickUp[id]);
    }
}
