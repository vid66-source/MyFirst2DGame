using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    private int playerScore;
    private int playerHighScore;
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private TextMeshProUGUI highScoreCount;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject splashSpawnObj; 
    private SplashSpawnScirpt splashScript;
    private bool eventDeathHappend = false;
    [SerializeField] GameObject audioManager;
    private AudioManager audioManagerScript;

    private void Start(){
            splashScript = splashSpawnObj.GetComponent<SplashSpawnScirpt>();
            audioManagerScript = audioManager.GetComponent<AudioManager>();
            playerHighScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreCount.text = playerHighScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
          playerScore = playerScore + scoreToAdd;
          scoreCount.text = playerScore.ToString();
    }

    private void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        if (!eventDeathHappend)
        {
            gameOverScreen.SetActive(true);
            splashScript.SpawnMultipleSplash();
            splashScript.SpawnMultipleDrops();
            audioManagerScript.SoundsOnDeath();
            audioManagerScript.SquishySoundsOnDeath();
            eventDeathHappend = true;
            if (playerScore > playerHighScore)
            {
                playerHighScore = playerScore;
                highScoreCount.text = playerHighScore.ToString();
                PlayerPrefs.SetInt("HighScore", playerHighScore);
                PlayerPrefs.Save();
            }
        }
    }
}
