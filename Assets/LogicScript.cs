using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour {
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public Camera mainCamera;

    [ContextMenu("Increase Score")]
    public void addScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        if (playerScore == 50) {
            mainCamera.backgroundColor = new Color(1.0f, 0.65f, 1.0f);
        } else if (playerScore == 100) {
            mainCamera.backgroundColor = new Color(1.0f, 1.0f, 1.0f);
        }
    }

    [ContextMenu("Game Over")]
    public void gameOver() {
        gameOverScreen.SetActive(true);
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
