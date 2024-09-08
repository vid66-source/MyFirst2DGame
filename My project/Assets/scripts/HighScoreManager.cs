using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure to import TMPro for TextMeshPro functionality


public class HighScoreManager : MonoBehaviour
{
    private static int highScore = 0;
    public static HighScoreManager Instance { get; private set; }
    
        private void Awake()
    {
        // Check if instance already exists and destroy duplicate
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public static void CheckAndUpdateHighScore(int currentScore)
    {
        // Update high score if the current score is higher
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Save the changes to disk
        }
    }
    public static int GetHighScore()
    {
        return highScore;
    }
}
