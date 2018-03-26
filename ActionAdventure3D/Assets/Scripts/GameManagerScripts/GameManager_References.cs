using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_References : MonoBehaviour
{

    public string playerTag;
    public static string _playerTag;

    public string enemyTag;
    public static string _enemyTag;

    public static GameObject _player;

    void OnEnable()
    {
        if(playerTag == "")
        {
            Debug.LogWarning("playerTag in the GameManager_References is empty.");
        }

        if (enemyTag == "")
        {
            Debug.LogWarning("enemyTag in the GameManager_References is empty.");
        }

        _playerTag = playerTag;
        _enemyTag = enemyTag;

        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }
}
