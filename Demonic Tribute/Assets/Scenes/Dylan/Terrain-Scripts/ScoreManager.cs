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

    void Start()
    {
        if (instance == null) 
        {
            instance = this;
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
            Debug.Log("Yay you won the game yippee yay ^-^");
        }
    }
}
