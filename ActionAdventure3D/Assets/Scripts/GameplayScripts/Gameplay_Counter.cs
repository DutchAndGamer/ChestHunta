using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gameplay_Counter : MonoBehaviour 
{
    private GameManager_Master gameManagerMaster;
    public TextMeshProUGUI chestCounter;
    public TextMeshProUGUI enemyCounter;
	
	void Update () 
	{
        CheckTheCounts();
	}
	
	void OnEnable () 
	{
        SetInitialReferences();
        SetUI();
	}
	
	void OnDisable () 
	{
		
	}
	
	void SetInitialReferences () 
	{
        gameManagerMaster = GetComponent<GameManager_Master>();
	}

    void CheckTheCounts()
    {
        SetUI();
    }

    void SetUI()
    {
        if (chestCounter != null)
        {
            chestCounter.text = "Chest: " + Chest_Counter.chestCount.ToString();
        }

        if (enemyCounter != null)
        {
            enemyCounter.text = "Enemies: " + Spawner_Proximity.enemyCount.ToString();
        }
    }
}
