using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 0.1f;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Camera cameraFollow;

    private Vector3 playerPosition;

    private void Start() {
        
    }

    private void Update() {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void LateUpdate() {
        cameraFollow.transform.position = transform.position + new Vector3 (0, 0, -10f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("we have collision");
        text.text = ("collision");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Package") {
            Debug.Log("Package picked-up");
            text.text = "Package";
        } else {
            Debug.Log("Delivered to customer");
            text.text = "Delivered!";
        }
    }
}
