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
            //Review - https://martalex.gitbooks.io/gameprogrammingpatterns/content/chapter-6/6.3-object-pool.html
            Destroy(gameObject);
        }
    }
    
    //Review - дивне вирівнювання)
        bool IsOffScreen()
    {
        Camera mainCamera = Camera.main;

        float extraOffset = mainCamera.orthographicSize * 0.5f;

        float screenLeftEdge = mainCamera.transform.position.x - (mainCamera.orthographicSize + extraOffset) * mainCamera.aspect;

        return transform.position.x < screenLeftEdge;
    }
}
