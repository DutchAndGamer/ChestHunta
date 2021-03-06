﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Strike : MonoBehaviour 
{
    private Melee_Master meleeMaster;
    private float nextSwingTime;
    public int damage = 25;

	void Start () 
	{
        SetInitialReferences();
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != GameManager_References._player && meleeMaster.isInUse && Time.time > nextSwingTime)
        {
            nextSwingTime = Time.time + meleeMaster.swingRate;
            collision.transform.SendMessage("ProcessDamage", damage, SendMessageOptions.DontRequireReceiver);
            meleeMaster.CallEventHit(collision, collision.transform);
            Debug.Log("Melee Hit");
        }
    }

    void SetInitialReferences () 
	{
        meleeMaster = GetComponent<Melee_Master>();
	}
}
