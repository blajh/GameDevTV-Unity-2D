using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigurationSO> waveConfigurationSOs;
    [SerializeField] private float timeBetweenWaves = 0f;
    private WaveConfigurationSO currentWave;

    private void Start() {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigurationSO GetCurrentWaveSO() {
        return currentWave;
    }
    private IEnumerator SpawnEnemyWaves() {        
        foreach (WaveConfigurationSO waveConfigurationSO in waveConfigurationSOs) {
            currentWave = waveConfigurationSO;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
                Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.identity,
                            transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
    }
}