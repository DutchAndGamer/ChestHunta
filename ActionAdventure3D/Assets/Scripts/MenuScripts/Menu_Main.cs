using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Main : MonoBehaviour
{
    //This function will be called when the PlayButton is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Chest_Counter.chestCount = 0;
        Spawner_Proximity.enemyCount = 0;
    }
	
    //This function will be called when the QuitButton is pressed
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //The application can not be closed inside the editor so it will display QUIT! in the console log
        Application.Quit();
    }
}
