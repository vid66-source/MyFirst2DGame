using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSpawnScirpt : MonoBehaviour
{
    public BirdScript birdScript;
    public GameObject splashPrefab;
    public GameObject markOnScreen;
    public int minSpawnCount = 2; // Minimum number of spawns
    public int maxSpawnCount = 5; // Maximum number of spawns
    private bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        if (birdScript == null)
        {
            birdScript = FindObjectOfType<BirdScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript.birdIsAlive == false && !hasSpawned){
            SpawnMultiple();
            hasSpawned = true;    
        }
        
    }

    void SpawnMultiple()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1); // Randomly choose number of spawns

        Camera mainCamera = Camera.main;

        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize;

        for (int i = 0; i < spawnCount; i++)
        {
            // Generate a random position within the screen bounds
            Vector3 spawnPosition = new Vector3(Random.Range(-screenWidth, screenWidth),Random.Range(-screenHeight, screenHeight),0);
            
            Instantiate(splashPrefab, spawnPosition, Quaternion.identity);
        }
    }
}


