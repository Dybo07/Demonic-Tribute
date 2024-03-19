using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public int day;
    public int TimeLeft;
    public bool TimerOn = false;

    public TMP_Text timeCounter;
    void Start()
    {
        StartCoroutine (updateTimer());
    }


    void Update()
    {
            timeCounter.text = " timeLeft: " + TimeLeft;
    }
    

    IEnumerator updateTimer()
    {
        yield return new WaitForSeconds(1);
        TimeLeft -= 1;
        if (TimeLeft >= 0)
        {
            StartCoroutine(updateTimer());
      
        }

    }
}
