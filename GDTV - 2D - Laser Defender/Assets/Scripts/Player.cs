using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.0f;

    private Vector2 rawInput;
    private Vector3 movementDelta;

    private void Update() {
        Move();
    }

    private void Move() {
        movementDelta = rawInput;
        transform.position += moveSpeed * Time.deltaTime * movementDelta;
    }

    private void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }
}
