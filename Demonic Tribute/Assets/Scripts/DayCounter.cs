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
        day = 1;
        timeLeft = 300;
        scoreManager.offerAmount = 10;

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

        if (scoreManager.offerItem.offerCount >= scoreManager.offerAmount)
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
    }

    IEnumerator DayCount()
    {
        switch(day)
        {
            case 1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 300;
                scoreManager.offerAmount = 10;
                break;

            case 2:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 300;
                scoreManager.offerAmount = 20;
                break;

            case 3:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft = 
                scoreManager.offerAmount = 25;
                break;

            case 4:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 30;
                break;

            case 5:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 40;
                break;

            case 6:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 50;
                break;

            case 7:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 60;
                break;

            case 8:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 69;
                break;

            case 9:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 100;
                break;

            case 10:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timeLeft =
                scoreManager.offerAmount = 1;
                break;

            default:
                break;
        }
        yield return new WaitForSeconds(1);
    }
}
