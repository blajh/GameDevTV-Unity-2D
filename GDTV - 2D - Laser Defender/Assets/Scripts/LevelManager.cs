using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float deathLoadDelay = 2f;

    public void LoadGameScene() {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu() {
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
}
