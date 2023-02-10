using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public bool hasCrashed = false;

    [SerializeField] private float angularChange = 1f;
    [SerializeField] private float baseSpeed = 15f;
    [SerializeField] private float boostSpeed = 20f;
    [SerializeField] private Transform environment;    

    private SurfaceEffector2D surfaceEffector;
    private Rigidbody2D rb2D;


    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector = environment.GetComponent<SurfaceEffector2D>();
    }

    private void Update() {
        RotatePlayer();
        RespondToBoost();
        CheckForCrash();
    }

    private void CheckForCrash() {
        if (hasCrashed) {
            surfaceEffector.speed = 0f;
        }
    }

    private void RotatePlayer() {
        if (Input.GetKey(KeyCode.A) && !hasCrashed) {
            rb2D.AddTorque(angularChange);
        }

        if (Input.GetKey(KeyCode.D) && !hasCrashed) {
            rb2D.AddTorque(-angularChange);
        }
    }

    private void RespondToBoost() {
        if (Input.GetKey(KeyCode.W)) {
            surfaceEffector.speed = boostSpeed;
        } else {
            surfaceEffector.speed = baseSpeed;
        }   
    }
}
