using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RestartLevel : MonoBehaviour
{

    private GameManager_Master gameManagerMaster;
    public bool hasRestarted = false;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.RestartLevelEvent += RestartLevel;
    }

    void OnDisable()
    {
        gameManagerMaster.RestartLevelEvent -= RestartLevel;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    public void RestartLevel()
    {
        hasRestarted = true;
        Chest_Counter.chestCount = 0;
        Spawner_Proximity.enemyCount = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
