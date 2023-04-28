using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 5f; // speed of the enemy
    public float moveDistance = 5f; // distance the enemy moves left and right
    public float chaseRange = 10f; // range at which the enemy starts chasing the player

    private bool movingRight = true; // determines direction of movement
    private Vector3 startPosition; // starting position of the enemy

    private Transform player; // player's transform
    private bool playerInRange = false; // is the player in range of the enemy?

    private SpriteRenderer spriteRenderer; // sprite renderer component for the enemy

    // get the player's transform and sprite renderer component
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // move the enemy left and right
    void Update()
    {
        if (!playerInRange)
        {
            if (movingRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                spriteRenderer.flipX = true; // face left
            }
            else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                spriteRenderer.flipX = false; // face right
            }

            // check if the enemy has reached the limit of its movement range
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
            else if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
        else
        {
            // chase the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // stop chasing if the player is out of range
            if (Vector2.Distance(transform.position, player.position) > chaseRange)
            {
                playerInRange = false;
            }
        }
    }

    // check for collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    // stop chasing the player if they escape the range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
