using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSpawnScirpt : MonoBehaviour
{
    public BirdScript birdScript;
    public GameObject splashPrefab;
    public GameObject[] markOnScreen;
    public int minSpawnCountSplash;
    public int maxSpawnCountSplash;
    public int minSpawnCountDrops;
    public int maxSpawnCountDrops;
    private bool hasSpawned = false;
    public string sortingLayerName = "Foreground";
    public int sortingOrder = 1;
    public float dropMinScale;
    public float dropMaxScale;
    // Start is called before the first frame update
    void Start()
    {

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
        int spawnCountSplash = Random.Range(minSpawnCountSplash, maxSpawnCountSplash + 1); // Randomly choose number of spawns

        Camera mainCamera = Camera.main;

        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;

        float screenHeight = mainCamera.orthographicSize;

        for (int i = 0; i < spawnCountSplash; i++)
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
        int spawnCountDrops = Random.Range(minSpawnCountDrops, maxSpawnCountDrops + 1);

        // Spawn the prefabs
        for (int i = 0; i < spawnCountDrops; i++)
        {
            // Generate a random position within the camera's view
            Vector3 spawnPosition = new Vector3(Random.Range(-screenWidth, screenWidth),Random.Range(-screenHeight, screenHeight),0);

            // Convert the position from the local camera space to world space
            spawnPosition = mainCamera.transform.position + spawnPosition;
            spawnPosition.z = 0;

            // Randomly select a prefab from the array
            GameObject selectedPrefab = markOnScreen[Random.Range(0, markOnScreen.Length)];

            // Instantiate the selected prefab at the generated position
            GameObject instantiatedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

            Renderer prefabRenderer = instantiatedObject.GetComponent<Renderer>();
            
            float randomScale = Random.Range(dropMinScale, dropMaxScale);
            instantiatedObject.transform.localScale = new Vector3(randomScale, randomScale, 1);
            
            if (prefabRenderer != null)
            {
                prefabRenderer.sortingLayerName = sortingLayerName;
                prefabRenderer.sortingOrder = sortingOrder;
            }
        }
    }
}


