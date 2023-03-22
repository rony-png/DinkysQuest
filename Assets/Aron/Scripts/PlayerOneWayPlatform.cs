using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{

    [SerializeField] private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    private void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("I pressed down");
                if (currentOneWayPlatform != null)
                {
                    StartCoroutine(DisableCollision());
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            Debug.Log("Collided with Platform");
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            Debug.Log("Exited with Platform");
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        Debug.Log("Disabling colliders");
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
