using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HealthIncrease : MonoBehaviour 
{
    private Player_Master playerMaster;

    void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventPickedUpHealthItem += UseHealthItem;

    }

    void OnDisable()
    {
        playerMaster.EventPickedUpHealthItem -= UseHealthItem;
    }

    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player_Master>();

    }

    void UseHealthItem(int increaseHealth)
    {
        playerMaster.CallEventPlayerHealthIncrease(increaseHealth);
    }
}
