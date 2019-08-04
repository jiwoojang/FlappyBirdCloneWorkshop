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
        if (GameController.instance.isPlaying) {
            pipeTransform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Boundary")) {
            Destroy(pipeTransform.gameObject);
        }
    }
}
