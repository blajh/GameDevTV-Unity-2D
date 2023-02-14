using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigurationSO waveConfigurationSO;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Start() {
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
