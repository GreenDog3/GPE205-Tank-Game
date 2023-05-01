using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public void GameStart()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateGameplayScreen();
        }
    }
}
