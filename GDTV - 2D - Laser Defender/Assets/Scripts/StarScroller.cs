using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    [SerializeField] private float upperBound;
    [SerializeField] private float lowerBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float leftBound;

    private void Update() {
        Move();
        CheckPosition();
    }

    private void Move() {
        transform.position += (Vector3) moveSpeed * Time.deltaTime;
    }

    private void CheckPosition() {
        if (transform.position.y <= lowerBound) {
            transform.position = new Vector3 (UnityEngine.Random.Range(leftBound, rightBound), upperBound, transform.position.z);
        }
    }
}
