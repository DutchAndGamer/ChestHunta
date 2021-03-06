﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CollisionField : MonoBehaviour 
{
    private Enemy_Master enemyMaster;
    private Rigidbody rigidBodyStrikingMe;
    private int damageToApply;
    public float massRequirement = 50;
    public float speedRequirement = 5;
    private float damageFactor = 0.1f;
	
	void OnEnable () 
	{
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
	}
	
	void OnDisable () 
	{
        enemyMaster.EventEnemyDie -= DisableThis;
    }
	
	void SetInitialReferences () 
	{
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            rigidBodyStrikingMe = other.GetComponent<Rigidbody>();

            if (rigidBodyStrikingMe.mass >= massRequirement && rigidBodyStrikingMe.velocity.sqrMagnitude > speedRequirement * speedRequirement)
            {
                damageToApply = (int)(damageFactor * rigidBodyStrikingMe.mass * rigidBodyStrikingMe.velocity.magnitude);
                enemyMaster.CallEventEnemyDeductHealth(damageToApply);
            }
        }
    }

    void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
