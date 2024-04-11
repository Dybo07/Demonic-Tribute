using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameItem : MonoBehaviour
{

    public Item item;
    public InvManager invManager;
    
    public bool isPickedUp = false;

    void Update()
    {
    }

    public void OnCollisionEnter(Collision hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && isPickedUp == false) 
        {
            invManager = FindAnyObjectByType<InvManager>();
            isPickedUp = true;
            invManager.AddItem(item);
            Destroy(gameObject);
        }
    }
}
