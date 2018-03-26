using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay_Timer : MonoBehaviour 
{
    private float timer;
    private float timeOnClock;
    private bool isDone = false;
    private bool hasEntered = false;
    public TextMeshProUGUI timerTMPro;
    public TextMeshProUGUI endTimerTMPro;
    public static int targetCounterEnd;
    public GameObject EndScreen;
    private bool isCursorLocked = true;


    void Start () 
	{
        timer = 0;
        timeOnClock = 0;
	}
	
	void Update () 
	{
        TimeCounterStart();
        CheckIfCounterIsReached();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!hasEntered)
        {
            hasEntered = true;
        }
    }

    void TimeCounterStart()
    {
        if(!isDone && hasEntered)
        {
            timeOnClock = timer += Time.deltaTime;
            timerTMPro.text = timeOnClock.ToString("Timer: .00");
            endTimerTMPro.text = timeOnClock.ToString("Time: .00");
        }
    }

    public void CheckIfCounterIsReached()
    {
        if (Target_Master.targetCounter >= targetCounterEnd)
        {
            isDone = true;
            //CursorLock();
            //CheckForEndScreen();
        }
    }

    void CheckForEndScreen()
    {
        if(EndScreen != null)
        {
            EndScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Missing Endscreen");
        }
    }

    void CursorLock()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Time.timeScale = 0;
    }
}
