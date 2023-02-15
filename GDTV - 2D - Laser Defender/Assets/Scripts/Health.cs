using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem explosionFX;

    [SerializeField] private bool applyCameraShake = false;
    CameraShake cameraShake;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null) {
            TakeDamage(damageDealer.GetDamageValue());
            PlayExplosionFX();
            damageDealer.Hit();
            ShakeCamera();
        }
    }

    private void TakeDamage(int damageValue) {
        health -= damageValue;
        if(health <= 0) {
            Destroy(gameObject);
        }
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
}
