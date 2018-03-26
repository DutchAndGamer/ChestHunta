using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Interacted : MonoBehaviour 
{
    private Chest_Master chestMaster;
    private Transform myTransform;
    private Rigidbody myRigidbody;
    private bool hasBeenOpened;
    private bool lootSpawned;
    public GameObject[] loot;
    public GameObject spawner;
    public GameObject spawnPoint;

    void OnEnable () 
	{
        SetInitialReferences();
        chestMaster.EventChestHasBeenOpened += ShootOutItems;
	}
	
	void OnDisable () 
	{
        chestMaster.EventChestHasBeenOpened -= ShootOutItems;
	}
	
	void SetInitialReferences () 
	{
        chestMaster = GetComponent<Chest_Master>();
        myTransform = transform;

        if(GetComponent<Rigidbody>() != null)
        {
            myRigidbody = GetComponent<Rigidbody>();
        }
	}

    bool CheckIfChestIsOpen()
    {
        if(chestMaster.isOpen == true)
        {
            hasBeenOpened = true;
            return true;
        }
        else
        {
            hasBeenOpened = false;
            return false;
        }
    }

    void ShootOutItems()
    {
        CheckIfChestIsOpen();

        if(hasBeenOpened && !lootSpawned)
        {
            Debug.Log("Chest has been opened");
            Instantiate(loot[Random.Range(0, loot.Length)], spawnPoint.transform.position, Quaternion.identity);
            Instantiate(spawner, spawnPoint.transform.position, Quaternion.identity);
            lootSpawned = true;
            DisableThis();
        }
        else
        {
            Debug.Log("Chest has not been opened yet");
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
