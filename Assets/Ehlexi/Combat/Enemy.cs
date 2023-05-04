using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    // Reduce player health on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= 1; // Reduce player health by 1
        }
    }

    // Destroy the enemy when its health is zero or less
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
