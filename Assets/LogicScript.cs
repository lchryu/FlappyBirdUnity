using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    // Best Score
    public int bestScore;
    public Text bestScoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PipeMoveScript.moveSpeed = 5;

        // Save bestScore to PlayerPrefs
        PlayerPrefs.SetInt("BestScore", bestScore);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        PipeMoveScript.moveSpeed = 0;
    }
    void Start()
    {
        // Load bestScore from PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        // Update bestScoreText
        bestScoreText.text = bestScore.ToString();
    }
}
