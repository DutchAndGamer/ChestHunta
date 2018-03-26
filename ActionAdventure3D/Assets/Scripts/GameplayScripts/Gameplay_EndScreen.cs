using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_EndScreen : MonoBehaviour 
{
    private GameManager_Master gameManagerMaster;
    private GameManager_RestartLevel gameManagerRestartLevel;
    private bool justRestarted;

    void Start()
    {
        SetInitialReferences();
    }

    void FixedUpdate()
    {
        CheckHowManyLeft();
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
        gameManagerRestartLevel = GetComponent<GameManager_RestartLevel>();
    }

    void CheckHowManyLeft()
    {
        if (gameManagerRestartLevel.hasRestarted)
        {
            justRestarted = true;
        }

        if(Chest_Counter.chestCount == 0 && !justRestarted)
        {
            if(Spawner_Proximity.enemyCount == 0 && Spawner_Proximity.hasSpawned)
            {
                gameManagerMaster.CallEventEndScreen();
            }
        }
    }
}
