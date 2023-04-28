using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerHealth playerHealth;

    private void Start()
    {
       // playerHealth = GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            Debug.Log("Game Over");
            playerHealth.health--;
            if(playerHealth.health <=0)
            {
                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
        
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

}


