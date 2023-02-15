using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 1f;

    [Header("Damage Taken")]
    [SerializeField] private AudioClip damageTakenClip;
    [SerializeField][Range(0f, 1f)] private float damageTakenVolume = 1f;

    public void PlayShootingClip() {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageTakenClip() {
        PlayClip(damageTakenClip, damageTakenVolume);
    }

    private void PlayClip(AudioClip clip, float volume) {
        Vector3 cameraPos = Camera.main.transform.position;
        if (clip != null) {
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
