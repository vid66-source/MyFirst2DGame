using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMoveScript : MonoBehaviour
{
    private float moveSpeed = 4;

    void Update()
    {
         transform.position += Vector3.left * moveSpeed * Time.deltaTime;

         if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }
        bool IsOffScreen()
    {
        Camera mainCamera = Camera.main;

        float extraOffset = mainCamera.orthographicSize * 0.5f;

        float screenLeftEdge = mainCamera.transform.position.x - (mainCamera.orthographicSize + extraOffset) * mainCamera.aspect;

        return transform.position.x < screenLeftEdge;
    }
}
