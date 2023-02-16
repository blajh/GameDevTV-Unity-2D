using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int healthMax = 50;
    [SerializeField] private ParticleSystem explosionFX;
    private int health;

    [Header("Camera Shake")]
    [SerializeField] private bool applyCameraShake = false;
    CameraShake cameraShake;

    [Header("Slow Motion")]
    [SerializeField] private bool applySlowMotion = false;
    [SerializeField] private float slowMotionDuration = 2f;
    [SerializeField] private float slowMotionTimeScale = 0.5f;
    private float sloMoTimer = 0f;
    private bool gotHit = false;

    [Header("Score Points per Death")]
    [SerializeField] bool isPlayer = false;
    [SerializeField] private int scorePerDeath = 10;

    private AudioPlayer audioPlayer;
    private ScoreKeeper scoreKeeper;
    private UIDisplay uiDisplay;
    LevelManager levelManager;

    private void Awake() {
        health = healthMax;
        levelManager = FindObjectOfType<LevelManager>();
        uiDisplay = FindObjectOfType<UIDisplay>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null) {
            TakeDamage(damageDealer.GetDamageValue());
            PlayExplosionFX();
            damageDealer.Hit();
            ShakeCamera();
            gotHit = true;
            audioPlayer.PlayDamageTakenClip();
            UpdateUI();
        }
    }

    private void UpdateUI() {
        if (isPlayer) {
            uiDisplay.UpdateHealth(healthMax, health);
        }
    }

    private void Update() {
        if (applySlowMotion && gotHit) {
            SlowMotion();
        }
    }

    private void TakeDamage(int damageValue) {
        health -= damageValue;
        if(health <= 0) {
            Die();
        }
    }

    private void Die() {
        if (!isPlayer) {
            scoreKeeper.ModifyScore(scorePerDeath);
        } else if (isPlayer) {
            levelManager.LoadDeathScene();
        }
        Destroy(gameObject);
    }

    private void PlayExplosionFX() {
        if (explosionFX != null) {
            ParticleSystem instance = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera() {
        if (cameraShake != null && applyCameraShake) {
            cameraShake.Play();
        }
    }

    private void SlowMotion() {
        Time.timeScale = slowMotionTimeScale + ((1 - slowMotionTimeScale) * (sloMoTimer / slowMotionDuration));
        sloMoTimer += Time.deltaTime;
        if (Time.timeScale >= 1) {
            Time.timeScale = 1;
            gotHit = false;
            sloMoTimer = 0f;
        }
    }

    public int GetHealth() {
        return health;
    }
}