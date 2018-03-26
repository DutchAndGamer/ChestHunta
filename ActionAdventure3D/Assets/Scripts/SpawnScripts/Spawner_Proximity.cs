﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Proximity : MonoBehaviour 
{
    public GameObject objectToSpawn;
    private int numberToSpawn;
    public float proximity;
    private float checkRate;
    private float nextCheck;
    private Transform myTransform;
    private Transform playerTransform;
    private Vector3 spawnPosition;
    public static int enemyCount;
    public static bool hasSpawned = false;

	void Start () 
	{
        SetInitialReferences();
	}
	
	void Update () 
	{
        CheckDistance();
	}
	
	void SetInitialReferences () 
	{
        myTransform = transform;
        playerTransform = GameManager_References._player.transform;
        checkRate = Random.Range(0.8f, 1.2f);
        numberToSpawn = Random.Range(1, 4);
	}

    void CheckDistance()
    {
        if(Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            if(Vector3.Distance(myTransform.position, playerTransform.position) < proximity)
            {
                SpawnObjects();
                this.enabled = false;
            }
        }
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            enemyCount++;
            Debug.Log("Enemy Count = " + enemyCount);
            spawnPosition = myTransform.position + Random.insideUnitSphere * 5;
            Instantiate(objectToSpawn, spawnPosition, myTransform.rotation);
            hasSpawned = true;
        }
    }
}
