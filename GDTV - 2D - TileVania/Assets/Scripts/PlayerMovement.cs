using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const string IS_RUNNING = "isRunning";

    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] Transform playerVisual;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private Animator animator;
    private bool playerHasHorizontalSpeed;

    private void Start() {
        myRigidbody= GetComponent<Rigidbody2D>();
        animator = playerVisual.GetComponent<Animator>();
    }

    private void Update() {
        IsMoving();        
        Run();
        UpdateAnimation();
        FlipSprite();
    }

    private void IsMoving() {
        playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }

    private void UpdateAnimation() {
        animator.SetBool(IS_RUNNING, playerHasHorizontalSpeed);        
    }

    private void FlipSprite() {        
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    private void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();        
    }
}
