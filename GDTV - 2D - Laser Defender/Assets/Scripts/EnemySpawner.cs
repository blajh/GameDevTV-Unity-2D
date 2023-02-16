using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigurationSO> waveConfigurationSOs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping = true;
    private WaveConfigurationSO currentWave;
    private int waveCount = 0;
    private UIDisplay uiDisplay;
    private ScoreKeeper scoreKeeper;

    private void Awake() {
        uiDisplay = FindObjectOfType<UIDisplay>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigurationSO GetCurrentWaveSO() {
        return currentWave;
    }
    private IEnumerator SpawnEnemyWaves() {
        do {
            foreach (WaveConfigurationSO waveConfigurationSO in waveConfigurationSOs) {
                currentWave = waveConfigurationSO;
                waveCount++;
                uiDisplay.UpdateWave(waveCount);
                scoreKeeper.ModifyWave(1);
                for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);        
    }
}