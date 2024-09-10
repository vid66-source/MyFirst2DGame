using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerHighScore;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI highScoreCount;
    public GameObject gameOverScreen;
    public SplashSpawnScirpt splashScript;
    public BirdScript birdScript;
    private bool eventDeathHappend = false;
    private int highScore;
    
    [SerializeField] GameObject audioManager;
    private AudioManager audioManagerScript;

    public void Start(){
        audioManagerScript = audioManager.GetComponent<AudioManager>();
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreCount.text = highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
          playerScore = playerScore + scoreToAdd;
          scoreCount.text = playerScore.ToString();
    }

    public void restartGame(){
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
            if (playerScore > highScore)
            {
                highScore = playerScore;
                highScoreCount.text = highScore.ToString();
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
        }
    }
}
