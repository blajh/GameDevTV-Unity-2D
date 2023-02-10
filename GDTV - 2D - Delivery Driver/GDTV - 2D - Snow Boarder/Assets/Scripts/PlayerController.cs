using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float angularChange = 1;

    private Rigidbody2D rb2D;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        
        if (Input.GetKey(KeyCode.A)) {
            rb2D.AddTorque(angularChange);
        }

        if (Input.GetKey(KeyCode.D)) {
            rb2D.AddTorque(-angularChange);
        }

    }

    
}
