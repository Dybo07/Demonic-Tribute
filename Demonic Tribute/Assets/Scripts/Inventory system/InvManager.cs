using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;

public class InvManager : MonoBehaviour
{
    public InvSlot[] invSlots;
    public Item item;

    public GameObject InvItemPrefab;
    //public GameObject inGameItemPrefab;
    public GameObject inventoryGroup;
    public GameObject player;

    public RaycastHit hit;

    public bool toggleActive = false;
    public bool isOpen = false;
    public bool isFull = false; 

    public float reach = 10;

    public int score;

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
        return;
    }

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
        if (Input.GetButtonDown("tab"))
        {
            isOpen = !isOpen;
            toggleActive = !toggleActive;
            inventoryGroup.SetActive(toggleActive);
            Cursor.visible = toggleActive;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
