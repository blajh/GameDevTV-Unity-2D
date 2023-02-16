using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float deathLoadDelay = 2f;

    private ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGameScene() {
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            ResetWavesAndScore();
        }
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu() {
        ResetWavesAndScore();
        SceneManager.LoadScene(0);
    }

    public void LoadDeathScene() {
        StartCoroutine(WaitAndLoad(2, deathLoadDelay));
    }

    public void QuitGame() {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad(int sceneIndex, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

    private void ResetWavesAndScore() {
        scoreKeeper.ResetScore();
        scoreKeeper.ResetWaves();
    }
}
