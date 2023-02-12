using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D myRigidBody;
    private CapsuleCollider2D myCapsuleCollider;


    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update() {
        myRigidBody.velocity = new Vector2 (moveSpeed, 0);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    private void FlipEnemyFacing() {
        transform.localScale = new Vector2(-transform.localScale.x, 1f);
    }
}
