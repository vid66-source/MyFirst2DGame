using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    private SpriteRenderer spriteRenderer;
    public Sprite firstBirdSprite;
    public Sprite secondbirdSprite;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = firstBirdSprite;
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigibody.velocity = Vector2.up * flapStrength;
        }

        Camera mainCamera = Camera.main;

        // Convert the object's world position to viewport position
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the camera's view
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            birdIsAlive = false;
            logic.gameOver();
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
        logic.gameOver();
        birdIsAlive = false;
    }

    
}
