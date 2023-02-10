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
    [SerializeField] private float packageDestroyDelay = 0.5f;

    private bool hasPackage = false;

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
        if (collision.gameObject.tag == "Package") {
            if (!hasPackage) {
                hasPackage = true;
                Debug.Log("Package picked-up");
                text.text = "Package";
                Destroy(collision.gameObject, packageDestroyDelay);
            }
        } else {
            if (hasPackage) {
                Debug.Log("Delivered to customer");
                text.text = "Delivered!";
                hasPackage = false;
            }
        }
    }
}
