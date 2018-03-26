using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Master : MonoBehaviour
{

    public delegate void GameManagerEventHandler();
    public event GameManagerEventHandler MenuToggleEvent;
    public event GameManagerEventHandler InventoryUIToggleEvent;
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GoToMenuSceneEvent;
    public event GameManagerEventHandler GameOverEvent;
    public event GameManagerEventHandler EndScreenEvent;

    public bool isGameOver;
    public bool isInventoryUIOn;
    public bool isMenuOn;
    public bool isEndScreen;


    public void CallEventMenuToggle()
    {
        if(MenuToggleEvent != null)
        {
            MenuToggleEvent();
        }
    }

    public void CallEventInverntoryUIToggle()
    {
        if (InventoryUIToggleEvent != null)
        {
            InventoryUIToggleEvent();
        }
    }

    public void CallEventRestartLevel()
    {
        if (RestartLevelEvent != null)
        {
            RestartLevelEvent();
        }
    }

    public void CallEventGoToMenuScene()
    {
        if (GoToMenuSceneEvent != null)
        {
            GoToMenuSceneEvent();
        }
    }

    public void CallEventGameOver()
    {
        if (GameOverEvent != null)
        {
            isGameOver = true;
            GameOverEvent();
        }
    }

    public void CallEventEndScreen()
    {
        if (EndScreenEvent != null)
        {
            isEndScreen = true;
            EndScreenEvent();
        }
    }
}
