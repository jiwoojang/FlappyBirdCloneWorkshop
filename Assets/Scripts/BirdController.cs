﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private float flapForce = 5.0f;

    private Rigidbody2D birdRigidbody;
    private Vector2 flapDirection;

    private void Awake() {
        birdRigidbody = GetComponent<Rigidbody2D>();

        // This starts the physics as locked
        birdRigidbody.isKinematic = true;

        flapDirection = Vector2.up * flapForce;
    }

    public void Flap() {

        // Validate that the player is ready
        if (!GameController.instance.isPlaying) {
            return;
        }

        // Unlock the flapping if this is the first press
        if (birdRigidbody.isKinematic) {
            birdRigidbody.isKinematic = false;
        }

        // Stop moving down first
        birdRigidbody.velocity = Vector2.zero;

        // and FLAP!
        birdRigidbody.AddForce(flapDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Score")) {
            Debug.Log("Score incrementing!");

            GameController.instance.IncreaseScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
         if (collision.collider.gameObject.CompareTag("Pipe")) {
            GameController.instance.StopPlaying();

            // Freeze everything and restart
            birdRigidbody.velocity = Vector2.zero;
            birdRigidbody.isKinematic = true;
        }
    }
}
