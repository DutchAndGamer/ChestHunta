using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EndScreen : MonoBehaviour 
{
    private GameManager_Master gameManagerMaster;
    public GameObject endScreen;
    public GameObject menu;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.EndScreenEvent += TurnOnEndScreen;
    }

    void OnDisable()
    {
        gameManagerMaster.EndScreenEvent -= TurnOnEndScreen;

    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TurnOnEndScreen()
    {
        if (endScreen != null && menu != null)
        {
            endScreen.SetActive(true);
            menu.SetActive(true);
        }
    }
}
