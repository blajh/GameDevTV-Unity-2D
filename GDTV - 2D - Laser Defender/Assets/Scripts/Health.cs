using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null) {
            damageDealer.Hit();
            TakeDamage(damageDealer.GetDamageValue());
        }
    }

    private void TakeDamage(int damageValue) {
        health -= damageValue;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
