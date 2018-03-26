using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Potion : MonoBehaviour 
{
    private Item_Master itemMaster;
    private GameObject playerGo;
    public int healthAmount;

    void Start()
    {
        SetInitialReferences();
    }

    void OnEnable () 
	{
        SetInitialReferences();
        itemMaster.EventObjectPickup += TakePotion;
	}
	
	void OnDisable () 
	{
        itemMaster.EventObjectPickup -= TakePotion;
	}
	
	void SetInitialReferences () 
	{
        itemMaster = GetComponent<Item_Master>();
        playerGo = GameManager_References._player;
    }

    void TakePotion()
    {
        playerGo.GetComponent<Player_Master>().CallEventPickedUpHealthItem(healthAmount);
        Destroy(gameObject);
    }
}
