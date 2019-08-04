using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public BirdController birdController;
    public PipeSpawner pipeSpawner;

    // Set the flap key as the space key
    private KeyCode flapKey = KeyCode.Space;

    private bool hasStartedFlapping = false;

    // This function will change behaviour depepdning on platform
    private bool IsFlapKeyPressed() {
#if UNITY_IOS || UNITY_ANDROID
        return Input.touchCount > 0;
#else
        if (UnityEditor.EditorApplication.isRemoteConnected) {
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        }
        else {
            return Input.GetKeyDown(flapKey);
        }
#endif
    }

    private void Update() {
        if (IsFlapKeyPressed()) {

            // If this is the first flap, set the flag to true
            if (!hasStartedFlapping) {
                hasStartedFlapping = true;

                // Start the game if the first flap happened
                if (!GameController.instance.isPlaying) {
                    GameController.instance.StartPlaying();
                }

                // Start the pipes
                pipeSpawner.StartSpawningPipes();
            }

            if (GameController.instance.isPlaying) {
                Debug.Log("Flap!");
                birdController.Flap();
            }
        }
    }
}
