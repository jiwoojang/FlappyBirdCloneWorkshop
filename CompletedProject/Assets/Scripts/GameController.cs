using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton access
    public static GameController instance;
    public Text scoreText;
    public GameObject restartUI;
    public Text finalScoreText;

    private int score;

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void StartPlaying() {
        // Start the game if it was paused
        Time.timeScale = 1.0f;

        Debug.Log("Game started");
    }

    public void StopPlaying() {
        // Stop the game
        Time.timeScale = 0.0f;

        // Turn on the restart UI
        restartUI.SetActive(true);

        finalScoreText.text = "Final Score: " + score.ToString();

        Debug.Log("Game stopped");
    }

    public void RestartGame() {
        // Get this current scene
        Scene thisScene = SceneManager.GetActiveScene();

        // Restart it
        // Do this with build index incase scene names are the same
        SceneManager.LoadScene(thisScene.buildIndex);
    }

    private void Awake() {
        // Singleton enforcement
        if (instance == null) {
            instance = this;
        }
        else {
            Debug.LogError("More than once instance of the Game Controller Singleton. Deleting the old instance.");
            DestroyImmediate(instance);

            instance = this;
        }

        // Turn off the restart UI by default
        restartUI.SetActive(false);

        // Start the game
        StartPlaying();
    }
}
