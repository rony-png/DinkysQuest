using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float range = 5f;
    public Transform leftPoint;
    public Transform rightPoint;

    private bool isMovingRight = true;
    private Transform player;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if the player is within range
        if (Vector2.Distance(transform.position, player.position) <= range)
        {
            // Chase the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move left and right within the range
            if (isMovingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, rightPoint.position, moveSpeed * Time.deltaTime);
                if (transform.position.x >= rightPoint.position.x)
                {
                    isMovingRight = false;
                    spriteRenderer.flipX = true; // Flip the sprite when turning left
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, leftPoint.position, moveSpeed * Time.deltaTime);
                if (transform.position.x <= leftPoint.position.x)
                {
                    isMovingRight = true;
                    spriteRenderer.flipX = false; // Flip the sprite when turning right
                }
            }
        }
    }
}

