using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public List<int> Days;
    [Header("other variables")]
    public ScoreManager scoreManager;

    [Header("Days variables")]
    public int day;
    public TMP_Text daycount;

    [Header("Timer variables")]
    public int timeLeft;
    public int timeMin;
    public int timeSec;
    public bool timerOn = false;
    public TMP_Text timeCounter;

    [Header("Score variables")]
    public int d;
    void Start()
    {
        timeLeft = 250;
        StartCoroutine (UpdateTimer());
        StartCoroutine(Daycount());
    }


    void Update()
    {
        //timer script
        timeMin = timeLeft / 60;
        timeSec = timeLeft - (timeMin * 60);
        timeCounter.text = " timeLeft: " + string.Format ("{0:00}:{1:00}", timeMin, timeSec);

    }

    

    IEnumerator UpdateTimer()
    {
       yield return new WaitForSeconds(1);
       timeLeft -= 1;
       if (timeLeft >= 0)
       {
           StartCoroutine(UpdateTimer());
      
       }
    }

    IEnumerator Daycount()
    {
        if (scoreManager.offerItem.offerCount >= scoreManager.offerAmount)
        {
            day = +1;
            yield return new WaitForSeconds(25f);
            StartCoroutine(Daycount());
        }


    }
}
