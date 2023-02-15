using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;

    public int GetDamageValue() {
        return damageValue;
    }

    public void Hit() {
        Destroy(gameObject);
    }
}
