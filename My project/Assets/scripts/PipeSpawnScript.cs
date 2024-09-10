using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Review - модифікатори доступу в методах краще писати, щоб було зрозуміло, які методи публічні, а які приватні(навіть в стандартних юнітевих)
    // Update is called once per frame
    void Update()
    {
        // Review - так само мені не подобаєтся спавн по таймеру, краще спавнити по відстані, інакше змінівши шивдкість руху труб треба буде підгадувати який час ставити, бо їх тоді буде мало. А через використання відстані буде зрозуміло інтуітивна складність. Хоча це спорно
        if (timer < spawnRate){
            timer = timer + Time.deltaTime;
        }
        else{
            spawnPipe();
            timer = 0;
        }
    }

    // Review - модифікатори доступу
    void spawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset; 
        Vector3 pipespawnPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        Instantiate(pipe, pipespawnPosition, transform.rotation);
    }
}
