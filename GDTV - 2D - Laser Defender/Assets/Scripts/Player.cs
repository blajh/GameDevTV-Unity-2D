using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.0f;

    private Vector2 rawInput;

    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    private Vector2 minimumBounds;
    private Vector2 maximumBounds;

    private void Start() {
        InitializeBounds();
    }

    private void Update() {
        Move();
    }

    private void InitializeBounds() {
        Camera mainCamera = Camera.main;
        minimumBounds = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f));
        maximumBounds = mainCamera.ViewportToWorldPoint(new Vector2(1f, 1f));
    }

    private void Move() {
        Vector2 movementDelta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + movementDelta.x, minimumBounds.x + paddingLeft, maximumBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + movementDelta.y, minimumBounds.y + paddingBottom, maximumBounds.y - paddingTop);
        transform.position = newPosition;
    }

    private void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }
}