using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_GameOver : MonoBehaviour
{
    public GameObject menu;

    private GameManager_Master gameManagerMaster;
    public GameObject panelGameOver;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += TurnOnGameOverPanel;
    }

    void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= TurnOnGameOverPanel;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TurnOnGameOverPanel()
    {
        if (panelGameOver != null && menu != null)
        {
            panelGameOver.SetActive(true);
            menu.SetActive(true);
        }
    }

}
