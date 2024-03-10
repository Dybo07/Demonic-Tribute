using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameItem : MonoBehaviour
{

    public Item item;
    public InvManager invManager;
    
    public bool isPickedUp = false;

    public void OnCollisionEnter(Collision hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && isPickedUp == false) 
        {
            isPickedUp = true;
            invManager.AddItem(item);
            Destroy(gameObject);
        }
    }
}
