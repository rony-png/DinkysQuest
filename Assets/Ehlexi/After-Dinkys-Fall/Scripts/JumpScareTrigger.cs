using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public GameObject enemyPrefab; // assign the enemy prefab in the Inspector
    public GameObject spawnPoint; // assign the spawn point in the Inspector
    public float enemySpeed = 2.0f; // set the enemy's speed in the Inspector

    private bool hasSpawned = false; // flag to prevent multiple spawns

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            // spawn the enemy at the spawn point
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            // set the enemy's movement speed
            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            enemyRb.velocity = new Vector2(-enemySpeed, 0);

            // flip the enemy's sprite
            SpriteRenderer enemySprite = enemy.GetComponent<SpriteRenderer>();
            enemySprite.flipX = true;

            hasSpawned = true; // set the flag to true to prevent multiple spawns
        }
    }
}