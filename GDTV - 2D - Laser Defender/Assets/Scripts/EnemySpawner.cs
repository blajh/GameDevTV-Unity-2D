using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigurationSO currentWave;

    private void Start() {
        SpawnEnemies();
    }

    public WaveConfigurationSO GetCurrentWaveSO() {
        return currentWave;
    }

    private void SpawnEnemies() {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
            Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform);
        }
    }
}
