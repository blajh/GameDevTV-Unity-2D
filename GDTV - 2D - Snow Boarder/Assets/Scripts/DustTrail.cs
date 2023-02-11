using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private float stopParticlesDelay = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            particleSystem.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            Invoke("StopParticles", stopParticlesDelay);
        }
    }

    private void StopParticles() {
        particleSystem.Stop();
    }
}
