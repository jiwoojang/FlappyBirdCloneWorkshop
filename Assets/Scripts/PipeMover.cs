using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField]
    private Transform pipeTransform;

    [SerializeField]
    private float moveSpeed = 5.0f;

    private void Update() {
        // Move the pipe every frame that it is alive
        if (GameController.instance.isPlaying) {
            pipeTransform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // When we exit the play area, destroy the game object to save performance
        if (collision.gameObject.CompareTag("Boundary")) {
            Destroy(pipeTransform.gameObject);
        }
    }
}
