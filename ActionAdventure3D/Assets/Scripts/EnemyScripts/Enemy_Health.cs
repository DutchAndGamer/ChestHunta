using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour 
{
    private Enemy_Master enemyMaster;
    public int enemyMaxHealth = 100;
    public int enemyHealth = 100;
    public float healthLow = 25;
	
	void OnEnable () 
	{
        SetInitialReferences();
        enemyMaster.EventEnemyDeductHealth += DeductHealth;
        enemyMaster.EventEnemyIncreaseHealth += IncreaseHealth;
	}
	
	void OnDisable () 
	{
        enemyMaster.EventEnemyDeductHealth -= DeductHealth;
        enemyMaster.EventEnemyIncreaseHealth -= IncreaseHealth;
    }
	
	void SetInitialReferences () 
	{
        enemyMaster = GetComponent<Enemy_Master>();
	}

    void DeductHealth(int healthChange)
    {
        enemyHealth -= healthChange;
        if(enemyHealth <= 0)
        {
            enemyHealth = 0;
            enemyMaster.CallEventEnemyDie();
            Spawner_Proximity.enemyCount--;
            Destroy(gameObject, Random.Range(10, 20));
        }

        CheckHealthFraction();
    }

    void CheckHealthFraction()
    {
        if (enemyHealth <= healthLow && enemyHealth > 0)
        {
            enemyMaster.CallEventEnemyHealthLow();
        }

        if (enemyHealth > healthLow)
        {
            enemyMaster.CallEventEnemyHealthRecovered();
        }
    }

    void IncreaseHealth(int healthChange)
    {
        if(enemyHealth > enemyMaxHealth)
        {
            enemyHealth = enemyMaxHealth;
        }

        CheckHealthFraction();
    }
}
