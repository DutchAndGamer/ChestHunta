using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay_Score : MonoBehaviour 
{
    private float timer;
    private float timeOnClock;
    private bool isDoneYet = false;
    private bool hasEntered = false;


    void Start()
    {
        timer = 0;
        timeOnClock = 0;
    }

    void Update()
    {
        TimeCounterStart();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasEntered)
        {
            hasEntered = true;
        }
    }

    void TimeCounterStart()
    {
        if (!isDoneYet && hasEntered)
        {
            timeOnClock = timer += Time.deltaTime;
            Debug.Log("TIMER TEST START");
            //timerTMPro.text = timeOnClock.ToString(".00");
        }
        else
        {
            Debug.Log("HELP");
        }

    }
}
