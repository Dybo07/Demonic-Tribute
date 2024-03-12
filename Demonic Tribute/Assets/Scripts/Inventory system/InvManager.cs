using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvManager : MonoBehaviour
{
    public InvSlot[] invSlots;
    public Item item;

    public GameObject InvItemPrefab;
    public GameObject inGameItemPrefab;
    public GameObject inventoryGroup;
    public GameObject player;

    public bool toggleActive = false;
    public bool isOpen = false;

    //adds item from outside the game to inventory
    public void AddItem(Item item) 
    {
        //check for place to add an item.
        for (int i = 0; i < invSlots.Length; i++) 
        {
            //store individual slot inside slot var.
            InvSlot slot = invSlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    //spawns item inside inventory by retrieving an item from AddItem function.
    public void SpawnNewItem(Item item, InvSlot slot)
    {
        GameObject newItem = Instantiate(InvItemPrefab, slot.transform);
        InventoryItem invItem = newItem.GetComponent<InventoryItem>();
        invItem.Init_Item(item);
    }

    public void Start()
    {
        inventoryGroup.SetActive(toggleActive);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                player.GetComponent<DebugPlayerMovement>().mouseSens = 0;
                player.GetComponent<DebugPlayerMovement>().speed = 0;
            }
            else 
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.GetComponent<DebugPlayerMovement>().speed = 5;
                player.GetComponent<DebugPlayerMovement>().mouseSens = 400f;
            }
            toggleActive = !toggleActive;
            inventoryGroup.SetActive(toggleActive);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
