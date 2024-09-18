using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4;
    private float extraOffset = 15;
    private Camera mainCamera;

    void Start()
    {
        // Присвоюємо основну камеру
        mainCamera = Camera.main;
    }

    void Update()
    {
         transform.position += Vector3.left * moveSpeed * Time.deltaTime;

         if (IsOffScreen())
        {
            // Повертаємо хмару в пул
            gameObject.SetActive(false);
            CloudPool.Instance.ReturnToPool(gameObject);
        }
    }
    
    //Review - а так?
        bool IsOffScreen()
    {

        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        return screenPosition.x < -extraOffset;
    }
}
