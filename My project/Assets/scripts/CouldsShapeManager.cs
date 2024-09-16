using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldsShapeManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public Sprite[] cloudShapesArray;
    public GameObject cloudShape;
    public float offScreenDistance = 5;
    // Start is called before the first frame update
    public GameObject SpawnRandomCloud(){
        int randomCloudShape = Random.Range(0, cloudShapesArray.Length);
        Sprite selectedCloudSprite = cloudShapesArray[randomCloudShape];

        // Get the camera and its view dimensions
        float screenRightEdge = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;

         // Position to the right of the screen
        Vector3 cloudSpawnPosition = new Vector3(screenRightEdge + offScreenDistance, Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize, mainCamera.transform.position.y + mainCamera.orthographicSize), 0);
        
        GameObject spawnedCloud = Instantiate(cloudShape, cloudSpawnPosition, Quaternion.identity);

        SpriteRenderer spriteRenderer = spawnedCloud.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = selectedCloudSprite;

        return spawnedCloud;
    }
}