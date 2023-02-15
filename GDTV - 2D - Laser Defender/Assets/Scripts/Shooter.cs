using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float firingRate = .2f;

    public bool isFiring;
    private Coroutine firingCoroutine;

    private void Update() {
        Fire();
    }

    private void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuosly());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuosly() {
        do {
            GameObject instance =  Instantiate(projectilePrefab,
                                               transform.position,
                                               Quaternion.identity);
            
            Rigidbody2D my_rb = instance.GetComponent<Rigidbody2D>();
            if (my_rb != null) {
                my_rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        } while (isFiring);
    }
}
