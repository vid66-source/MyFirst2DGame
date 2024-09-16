using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPool : MonoBehaviour
{
    public static CloudPool Instance;
    public GameObject[] cloudPrefabs; // Масив з 5 префабів
    public int poolSize = 20; // Розмір пулу

    private List<GameObject> pool;
    public static event System.Action OnCloudReturned;

    void Awake(){
        Instance = this;
        InitializePool();
    }

    private void InitializePool(){
        pool = new List<GameObject>();        
        for (int i = 0; i< poolSize; i++){
            GameObject cloud = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)]);
            cloud.SetActive(false);
            pool.Add(cloud);
            cloud.AddComponent<CloudsMoveScript>();
        }
    }

    public GameObject GetFromPool(){
        foreach (GameObject cloud in pool){
            if(!cloud.activeInHierarchy){
                return cloud;
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject cloud){
        cloud.SetActive(false);
        OnCloudReturned?.Invoke();
    }

    public IEnumerable<GameObject> GetAllClouds(){
        return pool;
    }
}
