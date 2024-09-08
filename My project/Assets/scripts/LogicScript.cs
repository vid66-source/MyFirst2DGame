using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public HighScoreManager highScoreManager;
    public TextMeshProUGUI highScoreText; // Reference to TextMeshProUGUI component

    void Start()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        int highScore = HighScoreManager.GetHighScore();
        highScoreText.text = highScore.ToString(); // Display only the number
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        HighScoreManager.CheckAndUpdateHighScore(playerScore);
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GameOverScreen is not assigned or has been destroyed.");
        }
    }
}
