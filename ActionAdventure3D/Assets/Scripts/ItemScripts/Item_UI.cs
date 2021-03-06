﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_UI : MonoBehaviour 
{

    private Item_Master itemMaster;
    public GameObject myUI;

    void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectThrow += DisableMyUI;
        itemMaster.EventObjectPickup += EnableMyUI;
    }

    void OnDisable()
    {
        itemMaster.EventObjectThrow -= DisableMyUI;
        itemMaster.EventObjectPickup -= EnableMyUI;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void EnableMyUI()
    {
        if (myUI != null)
        {
            myUI.SetActive(true);
        }
    }

    void DisableMyUI()
    {
        if (myUI != null)
        {
            myUI.SetActive(false);
        }
    }
}
