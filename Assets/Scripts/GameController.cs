using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton access
    public static GameController instance;

    public bool isPlaying { get; private set; }

    public int score { get; private set; }

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private Text finalScoreText;

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void StartPlaying() {
        isPlaying = true;
    }

    public void StopPlaying() {
        isPlaying = false;
        restartButton.SetActive(true);

        finalScoreText.text = "Final Score: " + score.ToString();
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

        // Turn off the restart button by default
        restartButton.SetActive(false);
    }

    public void RestartGame() {
        // Get this current scene
        Scene thisScene = SceneManager.GetActiveScene();

        // Restart it
        // Do this with build index incase scene names are the same
        SceneManager.LoadScene(thisScene.buildIndex);
    }
}
