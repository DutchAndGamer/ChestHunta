using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Counter : MonoBehaviour 
{
    private Chest_Master chestMaster;
    public static int chestCount;
    private bool hasBeenOpened;
    private bool chestCheck = false;

    void Start()
    {
        CheckHowManyChest();
    }

    void Update()
    {
        CheckIfCountChanged();
    }

    void OnEnable () 
	{
        SetInitialReferences();
        //chestMaster.EventChestCounter += CheckHowManyChest;
	}
	
	void OnDisable () 
	{
        //chestMaster.EventChestCounter -= CheckHowManyChest;
    }
	
	void SetInitialReferences () 
	{
        chestMaster = GetComponent<Chest_Master>();

	}

    bool CheckIfChestIsOpen()
    {
        if (chestMaster.isOpen == true)
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

    void CheckHowManyChest()
    {
        CheckIfChestIsOpen();

        if(!hasBeenOpened)
        {
            chestMaster.chestCounter++;
            chestCount++;
            Debug.Log(chestCount);
        }
    }

    void CheckIfCountChanged()
    {
        CheckIfChestIsOpen();

        if (hasBeenOpened && !chestCheck)
        {
            Spawner_Proximity.hasSpawned = false;
            chestCheck = true;
            chestCount--;
            Debug.Log("Chest count = " + chestCount);
        }
    }
}
