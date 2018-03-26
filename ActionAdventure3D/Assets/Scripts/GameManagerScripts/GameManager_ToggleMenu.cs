using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleMenu : MonoBehaviour
{

    private GameManager_Master gameManagerMaster;
    public GameObject menu;


	void Start ()
    {
        Time.timeScale = 1;
        //ToggleMenu();
    }
	
	void Update ()
    {
        CheckForMenuToggleRequest();
	}

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += ToggleMenu;
        gameManagerMaster.EndScreenEvent += ToggleMenu;
    }

    void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleMenu;
        gameManagerMaster.EndScreenEvent -= ToggleMenu;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void CheckForMenuToggleRequest()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn && !gameManagerMaster.isEndScreen)
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if(menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
            gameManagerMaster.CallEventMenuToggle();
        }
        else
        {
            Debug.LogWarning("UI GameObject in toggle Menu in the inspector not found!");
        }
    }
}
