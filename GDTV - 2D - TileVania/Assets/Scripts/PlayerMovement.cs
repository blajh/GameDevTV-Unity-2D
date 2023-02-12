using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const string IS_RUNNING = "isRunning";
    private const string GROUND_LAYER_MASK = "Ground";

    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] Transform playerVisual;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    private Animator animator;
    private bool playerHasHorizontalSpeed;
    private Collider2D myCollider2D;

    private void Start() {
        myRigidbody= GetComponent<Rigidbody2D>();
        animator = playerVisual.GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
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
