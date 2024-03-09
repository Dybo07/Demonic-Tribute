using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngameItem : MonoBehaviour, IPointerDownHandler
{
    public Item item;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bababooey");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) 
        {
            Debug.Log("I am being draged whaaaaaaa!!!!!!!!11 ):");
            transform.position = eventData.position;
        }
    }
}
