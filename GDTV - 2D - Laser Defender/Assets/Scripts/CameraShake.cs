using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeMagnitude = 0.5f;

    private Vector3 initialPosition;

    private void Start() {
        initialPosition = transform.position;
    }

    public void Play() {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake() {
        float shakeTimer = 0f;
        while(shakeTimer < shakeDuration){
            transform.position = initialPosition + (Vector3) UnityEngine.Random.insideUnitCircle * shakeMagnitude;
            shakeTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (shakeTimer >= shakeDuration) {
            transform.position = initialPosition;
        }
    }
}
