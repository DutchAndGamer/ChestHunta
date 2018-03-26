using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Spawner : MonoBehaviour 
{
    private Chest_Master chestMaster;
    public GameObject chest;
    private int checkSpawn;
    private bool canSpawnChest;
    private bool hasChestSpawned;

    void Start()
    {
        CheckIfCanSpawn();
    }

    void OnEnable () 
	{
        SetInitialReferences();
        //chestMaster.EventSpawnChest += SpawnChest;
	}
	
	void OnDisable () 
	{
        //chestMaster.EventSpawnChest -= SpawnChest;
    }
	
	void SetInitialReferences () 
	{
        chestMaster = GetComponent<Chest_Master>();
    }

    void SpawnChest()
    {
        if (canSpawnChest)
        {
            Instantiate(chest, transform.position, transform.rotation);
            DisableThis();
        }
        else if (Chest_Counter.chestCount < 0)
        {
            Instantiate(chest, transform.position, transform.rotation);
            DisableThis();
        }
        else
        {
            DisableThis();
        }
    }

    void CheckIfCanSpawn()
    {
        checkSpawn = Random.Range(1, 100);

        if (checkSpawn > 50)
        {
            canSpawnChest = true;
        }
        else
        {
            canSpawnChest = false;
        }

        SpawnChest();
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
