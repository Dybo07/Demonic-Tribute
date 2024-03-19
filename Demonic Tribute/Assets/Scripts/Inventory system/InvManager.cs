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
    public GameObject inGameItemPrefab;
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
            toggleActive = !toggleActive;
            inventoryGroup.SetActive(toggleActive);
        }

        /* if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit ,reach)) 
            {
                if (hit.collider.gameObject.CompareTag("Altar")) 
                {
                    for (int i = 0; i < invSlots.Length; i++)
                    {
                        if (invSlots[i].transform.childCount != 0) 
                        {
                            Destroy(invSlots[i].GetComponentInChildren<InventoryItem>().gameObject);
                            score++;
                            break;
                        }
                    }
                }
            }
        } */
    }
}
