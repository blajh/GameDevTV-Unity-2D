using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";
    [SerializeField] private float levelLoadDelay = 1.0f;
    [SerializeField] private int numberOflevels = 3;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == TAG_PLAYER) {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel() {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<ScenePersist>().Reset();
        SceneManager.LoadScene((currentBuildIndex + 1) % numberOflevels);
    }    
}