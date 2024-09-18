using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public CloudPool cloudPool;
    public int maxClouds = 7;
    private float extraOffset = 15;
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        SpawnInitialClouds();
        CloudPool.OnCloudReturned += OnCloudReturned;
    }

    void OnDestroy(){
        CloudPool.OnCloudReturned -= OnCloudReturned;
    }

    private void OnCloudReturned(){
        if (GetActiveCloudsdCount() < maxClouds){
            SpawnCloud();
        }
    }
    
    private void SpawnCloud(){
        GameObject cloud = cloudPool.GetFromPool();
    
        float screenRightEdge = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;
        Vector3 cloudSpawnPosition = new Vector3(Random.Range((screenRightEdge + extraOffset),(screenRightEdge + 2 * extraOffset)), Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize, mainCamera.transform.position.y + mainCamera.orthographicSize), 0);

        cloud.transform.position = cloudSpawnPosition;
        cloud.transform.rotation = Quaternion.identity;
        cloud.SetActive(true);
    }

    private int GetActiveCloudsdCount(){
        int count = 0;
        foreach (var cloud in cloudPool.GetAllClouds()){
            if (cloud.activeInHierarchy){
                count++;
            }
        }
        return count;
    }
    private void SpawnInitialClouds()
    {
        for (int i = 0; i < maxClouds; i++)
        {
            GameObject cloud = cloudPool.GetFromPool();

            // Розрахунок позиції спавну
            float screenRightEdge = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;
            Vector3 cloudSpawnPosition = new Vector3(screenRightEdge + extraOffset + Random.Range(-10f, 10f), // Рандомна позиція x праворуч за межами екрану
            Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize, mainCamera.transform.position.y + mainCamera.orthographicSize), 0); // Рандомна позиція y в межах екрану

            // Активування та позиціонування хмари
            cloud.transform.position = cloudSpawnPosition;
            cloud.transform.rotation = Quaternion.identity;
            cloud.SetActive(true);

        }
    }   
}
