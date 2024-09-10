using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -30;
    
    
    // Review - Так само краще видалити, хоч тут +- і пофіг але пусті методи без потреби моветор
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone){
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
