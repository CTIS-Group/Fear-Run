using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public static class GameManager 
{
 
    public enum GameStates
    {
        MENU,
        PLAYING,
        OVER
    }
    public static GameStates gameState = GameStates.PLAYING;

    public static void CheckGameState(PlayerControl _P)
    {
        CameraShaker.Instance.ShakeOnce(5f, 5f, 0.2f, 0.2f);
        if (_P.playerLives <= 0)
        {
            gameState = GameStates.OVER;
            EndGame(_P);
        }
    }

    public static void EndGame(PlayerControl _P)
    {
        if (gameState != GameStates.OVER) throw new System.Exception("Gamestate is not OVER!");
        else //OVER ELSE
        {
            if (_P.gameObject == null) throw new System.Exception("Player gameobject not found.");
            else
            {
                Destroyer.Destroy(_P.gameObject);
                SceneManager.LoadScene("GameOverScene");
            }
        }//OVER ELSE
    }
}
