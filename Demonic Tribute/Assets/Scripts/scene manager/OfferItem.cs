using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class OfferItem : MonoBehaviour
{
    public ScoreManager scoreManager;
    public InvManager invManager;
    public InvSlot[] invSlots;
    public GameObject offerIndicator;

    public int offerCount = 0;
    public bool hasOffered = false;
    public bool isInRange = false;

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
            if (isInRange && !invManager.isOpen) 
            {
                for (int i = 0; i < invSlots.Length; i++)
                {
                    if (invSlots[i].transform.childCount != 0 && offerCount <= scoreManager.offerAmount)
                    {
                        GameObject invItem = invSlots[i].transform.GetChild(0).gameObject;
                        Destroy(invItem);
                        offerCount++;
                        //PlayerManager.instance.SaveScore(ScoreManager.instance.offerAmount, ScoreManager.instance.offerItem.offerCount);
                        break;
                    }
                }
            }
        }
        else
        {
            hasOffered = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Altar"))
        {
            isInRange = true;
            offerIndicator.GetComponent<TMP_Text>().text = "[Left click] to offer item";
        }
    }

    private void OnTriggerExit(Collider col)
    {
        isInRange = false;
        if (col.gameObject.CompareTag("Altar")) 
        {
            offerIndicator.GetComponent<TMP_Text>().text = null;
        }
    }
}
