using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem invItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            invItem.transform.SetParent(gameObject.transform);
        }
    }
}
