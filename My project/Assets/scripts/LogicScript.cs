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
    
    [SerializeField] GameObject audioManager;
    private AudioManager audioManagerScript;

    public void Start(){
        audioManagerScript = audioManager.GetComponent<AudioManager>();
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
        }
    }
}
