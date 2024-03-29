﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public BirdController birdController;
    public PipeSpawner pipeSpawner;

    // Set the flap key as the space key
    private KeyCode flapKey = KeyCode.Space;

    private bool hasStartedFlapping = false;

    // This function will change behaviour depending on platform
    private bool IsFlapKeyPressed() {
#if UNITY_IOS || UNITY_ANDROID
        return GetTouchInput();
#else
        if (UnityEditor.EditorApplication.isRemoteConnected) {
            // For remote debugging in mobile
            return GetTouchInput();
        }
        else {
            return GetDesktopInput();
        }
#endif
    }

    // For touch inputs
    // Mobile and debug Unity Remote
    private bool GetTouchInput() {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    // For regular keycap input
    private bool GetDesktopInput() {
        return Input.GetKeyDown(flapKey);
    }

    private void Update() {
        if (IsFlapKeyPressed()) {

            // If this is the first flap, set the flag to true
            if (!hasStartedFlapping) {
                hasStartedFlapping = true;

                // Start the pipes
                pipeSpawner.StartSpawningPipes();
            }

            Debug.Log("Flap!");
            birdController.Flap();
        }
    }
}
