using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 100; // Default health value

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Code to handle enemy death here
        Destroy(gameObject);
    }
}
