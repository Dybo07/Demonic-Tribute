using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameItem : MonoBehaviour
{
    public Item item;

    public Inventory inventory;

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
}
