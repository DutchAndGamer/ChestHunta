using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleInventoryUI : MonoBehaviour
{
    private GameManager_Master gameManagerMaster;

    [Tooltip("If game mode has an inventory, set to true.")]
    public bool hasInventory;
    public GameObject inventoryUI;
    public string toggleInventoryButton;

	void Start ()
    {
        SetInitialReferences();

    }
	
	void Update ()
    {
        CheckForInventoryUIToggleRequest();
	}

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();

        if(toggleInventoryButton == "")
        {
            Debug.LogWarning("ToggleInventoryButton string in GameManager_ToggleInventoryUI is empty.");
            this.enabled = false;
        }
    }

    void CheckForInventoryUIToggleRequest()
    {
        if(Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasInventory)
        {
            ToggleInventoryUI();
        }
    }

    public void ToggleInventoryUI()
    {
        if(inventoryUI != null)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
            gameManagerMaster.CallEventInverntoryUIToggle();
        }
    }
}
