using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float StartTimeBtwAttack;
    public int damage;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public GameObject particleSystemPrefab; // Reference to the particle system prefab
    public Transform particleSystemTransform; // Reference to the transform where the particle system should appear
    public float particleSystemDuration; // How long the particle system should last

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
                }

                // Instantiate a particle system prefab at a specific transform
                GameObject particleSystemInstance = Instantiate(particleSystemPrefab, particleSystemTransform.position, Quaternion.identity);

                // Destroy the particle system instance after a certain amount of time
                Destroy(particleSystemInstance, particleSystemDuration);
            }

            timeBtwAttack = StartTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
