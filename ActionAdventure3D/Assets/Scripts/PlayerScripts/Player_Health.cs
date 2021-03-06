﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Health : MonoBehaviour 
{

    private GameManager_Master gameManagerMaster;
    private Player_Master playerMaster;
    public int playerHealth;
    public TextMeshProUGUI healthText;
    public int maxHealth = 100;
    //public float testPainTime = 2;

	void Start () 
	{
        //StartCoroutine(TestHealthDeduction());
	}

    /*
    void Update()
    {
        testPainTime -= Time.deltaTime;
        if (testPainTime <= 0)
        {
            testPainTime = 2;
            playerMaster.CallEventPlayerHealthDeduction(25);
            return;
        }
    }
    */

    void OnEnable () 
	{
        SetInitialReferences();
        SetUI();
        playerMaster.EventPlayerHealthDeduction += DeductHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;

        
    }
	
	void OnDisable () 
	{
        playerMaster.EventPlayerHealthDeduction -= DeductHealth;
        playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    }
	
	void SetInitialReferences () 
	{
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<Player_Master>();
	}

    
    /*
    IEnumerator TestHealthDeduction()
    {
        yield return new WaitForSeconds(2);
        //DeductHealth(100);
        playerMaster.CallEventPlayerHealthDeduction(25);
    }
    */
    

    void DeductHealth(int healthChange)
    {
        playerHealth -= healthChange;

        if(playerHealth <= 0)
        {
            playerHealth = 0;
            gameManagerMaster.CallEventGameOver();
        }

        SetUI();
    }

    void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        SetUI();
    }

    void SetUI()
    {
        if(healthText != null)
        {
            healthText.text = playerHealth.ToString();
        }
    }
}
