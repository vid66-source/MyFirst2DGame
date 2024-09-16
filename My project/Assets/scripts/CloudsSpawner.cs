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
        //Review - це виглядає як вічний цикл що в цілому така собі практика, я б краще дивився скільки зараз активних хмар, якщо менше N - спавнимо нову. І робив це не циклом а евентом коли хмара дестроїтся
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