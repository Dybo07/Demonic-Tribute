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
    [Header("Days variables")]
    public int day;
    public TMP_Text daycount;

    //public ScoreManager scoreManager;   

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
        day = 1;
        timeLeft = 300;
        ScoreManager.instance.offerAmount = 10;
        //scoreManager = ScoreManager.instance;
        //scoreManager.offerAmount = 10;

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
            day = +1;
            StartCoroutine (DayCount());
        }
    }

    
    IEnumerator UpdateTimer()
    {
       yield return new WaitForSeconds(1);
       timeLeft -= 1;
        if (timeLeft >= 0)
        {
            StartCoroutine(UpdateTimer());

        }
        else if (timeLeft <= 0) 
        {
            if (day >= 7)
            {
                StartCoroutine(UpdateTimer());
                day++;
                timeLeft = 180;

            }
            else 
            {
                day++;
                timeLeft = 300;
            }
            //timeLeft = 300;
        }
    }

    IEnumerator DayCount()
    {
        /*
        switch(day)
        {
            case 1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 300;
                ScoreManager.instance.offerAmount = 10;
                break;

            case 2:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 300;
                ScoreManager.instance.offerAmount = 20;
                break;

            case 3:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 
                ScoreManager.instance.offerAmount = 25;
                break;

            case 4:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 30;
                break;

            case 5:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 40;
                break;

            case 6:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 50;
                break;

            case 7:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 60;
                break;

            case 8:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 69;
                break;

            case 9:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 100;
                break;

            case 10:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                ScoreManager.instance.offerAmount = 1;
                break;

            default:
                break;
        }
        */
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ScoreManager.instance.offerAmount += ScoreManager.instance.offerAmount;
            //for debugging enzo.
            Debug.Log(ScoreManager.instance.offerAmount);

        yield return new WaitForSeconds(1);
    }
}
