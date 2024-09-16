using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody2D myRigibody;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite firstBirdSprite;
    [SerializeField] private Sprite secondbirdSprite;
    [SerializeField] private float flapStrength ;
    [SerializeField] private GameObject logic;
    private LogicScript logicScript;
    internal bool birdIsAlive = true;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = firstBirdSprite;
        logicScript = logic.GetComponent<LogicScript>();
    }

    private void Update()
    {
        // Перевіряємо, чи птах живий
        if (birdIsAlive)
        {
            // Перевіряємо натискання клавіші пробіл
            if (Input.GetKey(KeyCode.Space))
            {
                // Змінюємо спрайт птаха на спрайт при натисканні клавіші
                spriteRenderer.sprite = firstBirdSprite;

                // Змінюємо швидкість при першому натисканні клавіші пробіл
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    myRigibody.velocity = Vector2.up * flapStrength;
                }
            }
            else
            {
                // Повертаємо спрайт птаха до початкового, коли клавіша відпущена
                spriteRenderer.sprite = secondbirdSprite;
            }
        }
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            birdIsAlive = false;
            logicScript.gameOver();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision){
        birdIsAlive = false;
        logicScript.gameOver();
    }
}
