using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Interactive : MonoBehaviour 
{
    private Chest_Master chestMaster;
    private Animator myAnimator;
    public GameObject chestLit;
    public bool openChest;
    private float openSmooth = 2.0f;
    private float chestOpenAngle = -150.0f;


    void OnEnable () 
	{
        SetInitialReferences();
        chestMaster.EventOpenChest += OpenChest;
    }
	
	void OnDisable () 
	{
        chestMaster.EventOpenChest -= OpenChest;
    }
	
	void SetInitialReferences () 
	{
        chestMaster = GetComponent<Chest_Master>();

        if(GetComponent<Animator>() != null)
        {
            myAnimator = GetComponent<Animator>();
        }
	}

    void OpenChest()
    {
        Debug.Log("Chest Interacted");

        if(myAnimator != null)
        {
            myAnimator.SetBool("isChestOpen", true);
        }

        chestMaster.isOpen = true;
    }
}
