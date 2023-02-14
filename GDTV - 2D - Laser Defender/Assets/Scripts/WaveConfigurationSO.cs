using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(menuName = "Wave Configuration SO", fileName = "New Wave Configuration SO")]
public class WaveConfigurationSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 4f;

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab) {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }
}
