using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int playerLivesMax = 3;
    [SerializeField] private int firstLevelSceneIndex = 0;
    private int playerLives = 3;

    private void Awake() {    

        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath() {
        if (playerLives > 1) {
            TakeLife();
        } else {
            ResetGameSession();
        }
    }

    private void TakeLife() {
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetGameSession() {
        playerLives = playerLivesMax;
        SceneManager.LoadScene(firstLevelSceneIndex);
    }
}
