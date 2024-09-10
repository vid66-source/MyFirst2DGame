using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript birdScript;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();

    } 
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 3 && birdScript.birdIsAlive){
        logic.addScore(1);
        }
    }
}
