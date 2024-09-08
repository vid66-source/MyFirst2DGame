using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public CouldsShapeManager cloudsShapeManager;  // Reference to SpriteManager
    public float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine
        StartCoroutine(SpawnSprites());
    }

    IEnumerator SpawnSprites()
    {
        while (true)
        {
            // Spawn a random sprite using the SpriteManager
            GameObject spawnedSprite  = cloudsShapeManager.SpawnRandomCloud();
            
            // Add the SpriteMover script to move the sprite
            spawnedSprite.AddComponent<CloudsMoveScript>();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
