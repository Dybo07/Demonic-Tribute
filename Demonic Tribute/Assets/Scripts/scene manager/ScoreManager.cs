using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    //singleton
    public static ScoreManager instance;

    public int offerAmount;
    public GameObject player;
    public OfferItem offerItem;

    public TMP_Text offerInfo;
    public GameObject offerIndicator;

    void Start()
    {
        
        offerItem = player.GetComponent<OfferItem>();
    }

    private void Awake()
    {
        //singleton thingy
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
        }
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
