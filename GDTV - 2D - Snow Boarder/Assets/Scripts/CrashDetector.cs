using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodParticleSystem;
    [SerializeField] private PlayerController playerController;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground" && !playerController.hasCrashed) {
            Debug.Log("Hit my head");
            audioSource.Play();
            bloodParticleSystem.Play();
            playerController.hasCrashed = true;
            Invoke("ReloadScene", 2f);
        }
    }

    private void ReloadScene() {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
