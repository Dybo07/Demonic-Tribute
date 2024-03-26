using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int offerAmount = 60;
    public GameObject player;
    public OfferItem offerItem;

    public TMP_Text offerInfo;
    public GameObject offerIndicator;

    void Start()
    {
        //singleton thingy
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null) 
        {
            Destroy(instance);
        }
        offerItem = player.GetComponent<OfferItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (offerItem.offerCount < offerAmount) 
        {
            offerInfo.text = "Offered items: " + offerItem.offerCount + " / " + offerAmount;
        }
        if (offerItem.offerCount == offerAmount) 
        {
            offerInfo.text = "Offered items: " + offerItem.offerCount + " / " + offerAmount;
        }
        if(player.GetComponent<OfferItem>().hasOffered) 
        {
            offerIndicator = player.GetComponent<OfferItem>().offerIndicator;
        }
    }
}
