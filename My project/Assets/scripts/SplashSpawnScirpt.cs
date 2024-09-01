using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSpawnScirpt : MonoBehaviour
{
    public BirdScript birdScript;
    public GameObject splashPrefab;
    public GameObject[] markOnScreen;
    public int minSpawnCountSplash = 2;
    public int maxSpawnCountSplash = 5;
    public int minSpawnCountDrops = 6;
    public int maxSpawnCountDrops = 12;
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
            SpawnMultipleSplash();
            SpawnMultipleDrops();
            hasSpawned = true;    
        }
        
    }

    void SpawnMultipleSplash()
    {
        int spawnCount = Random.Range(minSpawnCountSplash, maxSpawnCountSplash + 1); // Randomly choose number of spawns

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
    void SpawnMultipleDrops()
     {
        // Get the camera component
        Camera mainCamera = Camera.main;

        // Calculate screen bounds in world coordinates
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize;

        // Determine how many prefabs to spawn
        int spawnCount = Random.Range(minSpawnCountDrops, maxSpawnCountDrops + 1);

        // Spawn the prefabs
        for (int i = 0; i < spawnCount; i++)
        {
            // Generate a random position within the camera's view
            Vector3 spawnPosition = new Vector3(Random.Range(-screenWidth, screenWidth),Random.Range(-screenHeight, screenHeight),0);

            // Convert the position from the local camera space to world space
            spawnPosition = mainCamera.transform.position + spawnPosition;

            // Randomly select a prefab from the array
            GameObject selectedPrefab = markOnScreen[Random.Range(0, markOnScreen.Length)];

            // Instantiate the selected prefab at the generated position
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }
    }
}


