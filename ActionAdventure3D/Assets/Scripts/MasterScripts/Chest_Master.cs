using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Master : MonoBehaviour 
{
    public bool isOpen;
    public int chestCounter;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventOpenChest;
    public event GeneralEventHandler EventChestHasBeenOpened;
    public event GeneralEventHandler EventChestCounter;
    public event GeneralEventHandler EventSpawnChest;

    public void CallEventOpenChest()
    {
        if(EventOpenChest != null)
        {
            EventOpenChest();
        }
    }

    public void CallEventChestHasBeenOpened()
    {
        if(EventChestHasBeenOpened != null)
        {
            EventChestHasBeenOpened();
        }
    }

    /*public void CallEventChestCount()
    {
        if(EventChestCounter != null)
        {
            EventChestCounter();
        }
    }*/

    public void CallEventSpawnChest()
    {
        if (EventSpawnChest != null)
        {
            EventSpawnChest();
        }
    }
}
