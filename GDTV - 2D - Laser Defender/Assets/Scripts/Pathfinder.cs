using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigurationSO waveConfigurationSO;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Start() {
        waveConfigurationSO = enemySpawner.GetCurrentWaveSO();
        waypoints = waveConfigurationSO.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update() {
        FollowPath();
    }

    private void FollowPath() {
        if(waypointIndex < waypoints.Count) {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfigurationSO.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
