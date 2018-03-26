using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SetPosition : MonoBehaviour 
{
    private Item_Master itemMaster;
    public Vector3 itemLocalPosition;
    public Vector3 itemLocalRotation;

    void Start()
    {
        SetPositionOnPlayer();
        SetItemRotationToPlayer();
    }

    void OnEnable () 
	{
        SetInitialReferences();
        itemMaster.EventObjectPickup += SetPositionOnPlayer;
        itemMaster.EventObjectPickup += SetItemRotationToPlayer;
    }
	
	void OnDisable () 
	{
        itemMaster.EventObjectPickup -= SetPositionOnPlayer;
        itemMaster.EventObjectPickup -= SetItemRotationToPlayer;
    }
	
	void SetInitialReferences () 
	{
        itemMaster = GetComponent<Item_Master>();
    }

    void SetPositionOnPlayer()
    {
        if(transform.root.CompareTag(GameManager_References._playerTag))
        {
            transform.localPosition = itemLocalPosition;
        }
    }

    void SetItemRotationToPlayer()
    {
        if (transform.root.CompareTag(GameManager_References._playerTag))
        {
            transform.localRotation = Quaternion.Euler(itemLocalRotation.x, itemLocalRotation.y, itemLocalRotation.z);
        }
    }
}
