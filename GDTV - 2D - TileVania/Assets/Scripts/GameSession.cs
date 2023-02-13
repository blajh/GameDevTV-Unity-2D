using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] private int playerLives = 3;
    [SerializeField] private int firstLevelSceneIndex = 0;
    [SerializeField] private int scorePerCoin = 100;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake() {    

        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
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
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession() {
        SceneManager.LoadScene(firstLevelSceneIndex);
        FindObjectOfType<ScenePersist>().Reset();
        Destroy(gameObject);
    }

    public void AddToScore() {
        score += scorePerCoin;
        scoreText.text = score.ToString();
    }
}
