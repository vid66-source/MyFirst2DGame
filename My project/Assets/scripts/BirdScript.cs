using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Rigidbody2D myRigibody;
    private SpriteRenderer spriteRenderer;
    private Sprite firstBirdSprite;
    private Sprite secondbirdSprite;
    private float flapStrength;
    [SerializeField] GameObject logic;
    private LogicScript logicScript;
    internal bool birdIsAlive = true;
    private bool hasOhegaoDeathSound = false;
    private bool hasSquishDeathSound = false;
    [SerializeField] GameObject audioManager;
    private AudioManager audioManagerScript; //Review - варто завжди вказувати модіфікатори доступу
    // Start is called before the first frame update
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = firstBirdSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigibody.velocity = Vector2.up * flapStrength;
        }

        logicScript = logic.GetComponent<LogicScript>();

        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        audioManagerScript = audioManager.GetComponent<AudioManager>();

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            birdIsAlive = false;
            logicScript.gameOver();
            
            if(!hasOhegaoDeathSound){
                audioManagerScript.SoundsOnDeath();
                hasOhegaoDeathSound = true;
            }
            if(!hasSquishDeathSound){
                audioManagerScript.SquishySoundsOnDeath();
                hasSquishDeathSound = true;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Change to the pressed sprite
            spriteRenderer.sprite = firstBirdSprite;
        }
        else
        {
            // Revert back to the default sprite when the button is released
            spriteRenderer.sprite = secondbirdSprite;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        logicScript.gameOver();
        birdIsAlive = false;
        if(!hasOhegaoDeathSound){
            audioManagerScript.SoundsOnDeath();
            hasOhegaoDeathSound = true;
        }
        if(!hasSquishDeathSound){
            audioManagerScript.SquishySoundsOnDeath();
            hasSquishDeathSound = true;
        }
    }

    
}
