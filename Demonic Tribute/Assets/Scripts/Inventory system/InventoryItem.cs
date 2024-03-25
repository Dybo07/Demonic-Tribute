using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Transform parentAfterDrag;
    //ScriptableObject item. elke prefab heeft een andere item SO
    public Item item;
    public GameObject droppedItem;
    public GameObject inGameItemPrefab;
    public GameObject dropPoint;
    public InvManager invManager;
    public void Start()
    {
        dropPoint = GameObject.Find("DropPoint");
    }

    public void Init_Item(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        if (gameObject.transform.parent.name == "Inventory")
        {
            Destroy(gameObject);
        }
    }
}