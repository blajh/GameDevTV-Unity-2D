using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;

    [Header("Fire Rate")]
    [SerializeField] private float baseFiringRate = .2f;
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minimumFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] private bool useAI;

    [HideInInspector] public bool isFiring;

    private Coroutine firingCoroutine;

    private void Start() {
        if(useAI) {
            isFiring = true;
        }
    }

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
            yield return new WaitForSeconds(GetRandomFireRate());
        } while (isFiring);
    }

    public float GetRandomFireRate() {
        float spawnTime = Random.Range(baseFiringRate - firingRateVariance,
                                       baseFiringRate + firingRateVariance);
        return Mathf.Clamp(baseFiringRate, minimumFiringRate, float.MaxValue);
    }
}