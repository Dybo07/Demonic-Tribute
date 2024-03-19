using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OfferItem : MonoBehaviour
{

    public InvManager invManager;
    public InvSlot[] invSlots;

    public float reach = 1f;
    public int offerCount = 0;
    public RaycastHit rayHit;

    // Start is called before the first frame update
    void Start()
    {
        invSlots = invManager.invSlots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit, reach))
            {
                if (rayHit.collider.gameObject.CompareTag("Altar")) 
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayHit.distance, Color.red);
                    for (int i = 0; i < invSlots.Length; i++) 
                    {
                        if (invSlots[i].transform.childCount != 0) 
                        {
                            GameObject invItem = invSlots[i].transform.GetChild(0).gameObject;
                            Destroy(invItem);
                            offerCount++;
                            break;
                        }
                    }
                }
            }
        }
    }
}
