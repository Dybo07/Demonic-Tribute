using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCounter : MonoBehaviour
{
    public static DayCounter instance;
    [Header("Days variables")]
    public TMP_Text daycount;

    //public ScoreManager scoreManager;   

    [Header("Timer variables")]
    public int timeLeft;
    public int timeMin;
    public int timeSec;
    public bool timerOn = false;
    public int day;

    public TMP_Text timeCounter;

    public GameObject thePlayer;


    [Header("Score variables")]
    public int d;
    void Start()
    {
        day = 1;
        instance = this;
        timeLeft = 300;
        ScoreManager.instance.offerAmount = 10;

        StartCoroutine (UpdateTimer());
    }


    void Update()
    {
        //timer script
        timeMin = timeLeft / 60;
        timeSec = timeLeft - (timeMin * 60);
        timeCounter.text = " timeLeft " + string.Format (" {0:00}:{1:00} ", timeMin, timeSec);

        //daycount script
        daycount.text = "Day " + day;

        if (ScoreManager.instance.offerItem.offerCount >= ScoreManager.instance.offerAmount)
        {
            day++;
            Debug.Log(day);
            ScoreManager.instance.offerItem.offerCount = 0;
            Debug.Log(day);
            //deze singleton werkt niet.
            //PlayerManager.instance.dayCounter = day;
            Debug.Log(day);
            StartCoroutine (DayCount());
            Debug.Log(day);
        }
    }

    
    IEnumerator UpdateTimer()
    {
        yield return new WaitForSeconds(1);
        timeLeft -= 1;

        if (timeLeft > 0)
        {
            StartCoroutine(UpdateTimer());
        }
        else if (timeLeft <= 0) 
        {
            if (day == 6)
            {
                ScoreManager.instance.offerAmount = 25;
                StartCoroutine(UpdateTimer());
                day++;
                timeLeft = 180;
            }
            else 
            {
                day++;
                timeLeft = 300;
                StartCoroutine(UpdateTimer());
            }
            //timeLeft = 300;
        }
    }

    IEnumerator DayCount()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.instance.offerAmount += 10;
        thePlayer.transform.position = new Vector3(0f, 101.08f, 0f);
        //Debug.Log(ScoreManager.instance.offerAmount);

        yield return new WaitForSeconds(1);
    }
}
