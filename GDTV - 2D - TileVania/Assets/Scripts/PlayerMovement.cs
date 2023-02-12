using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const string IS_RUNNING = "isRunning";
    private const string IS_CLIMBING = "isClimbing";
    private const string GROUND_LAYER_MASK = "Ground";
    private const string CLIMBING_LAYER_MASK = "Climbing";

    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] float climbSpeed = 4.0f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] Transform playerVisual;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private Animator animator;
    private bool playerHasHorizontalSpeed;
    private bool playerHasVerticalSpeed;
    private Collider2D myCollider2D;
    private float myGravityScale;

    private void Start() {
        myRigidbody= GetComponent<Rigidbody2D>();
        myGravityScale = myRigidbody.gravityScale;
        animator = playerVisual.GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
    }

    private void Update() {
        IsMoving();
        Run();
        UpdateAnimation();
        FlipSprite();
        ClimbLadder();
    }

    private void IsMoving() {
        playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
    }

    private void Run() {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    private void UpdateAnimation() {
        animator.SetBool(IS_RUNNING, playerHasHorizontalSpeed);
        animator.SetBool(IS_CLIMBING, IsOnLadder() && playerHasVerticalSpeed);
    }

    private void FlipSprite() {        
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    private void ClimbLadder() {
        if (IsOnLadder()) {
            Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
            myRigidbody.velocity = playerVelocity;        
        }
        
    }

    private bool IsOnLadder() {
        LayerMask climbingLayerMask = LayerMask.GetMask(CLIMBING_LAYER_MASK);

        if (myCollider2D.IsTouchingLayers(climbingLayerMask)) {
            myRigidbody.gravityScale = 0;
        } else if (!myCollider2D.IsTouchingLayers(climbingLayerMask)) {
            myRigidbody.gravityScale = myGravityScale;
        }

        return myCollider2D.IsTouchingLayers(climbingLayerMask);
    }

    private void OnJump(InputValue value) {
        if (value.isPressed && IsGrounded()) {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    private void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();        
    }

    private bool IsGrounded() {
        LayerMask groundLayerMask = LayerMask.GetMask(GROUND_LAYER_MASK);
        return myCollider2D.IsTouchingLayers(groundLayerMask);
    }
}
