using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinkyFalling : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;
    public float timeUntilFall = 2f;
    public float gravity = 5f;
    public float timeBeforeMove = 0f;

    private float currentDistance = 0f;
    private float timeElapsed = 0f;
    private bool isFalling = false;
    private bool canMove = false;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartMoving", timeBeforeMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFalling && canMove)
        {
            if (currentDistance < distance)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                currentDistance += speed * Time.deltaTime;
            }
            else
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= timeUntilFall)
                {
                    isFalling = true;
                    rb2d.gravityScale = gravity;
                }
            }
        }
    }

    // Function called by Invoke to allow object to start moving
    void StartMoving()
    {
        canMove = true;
    }
}
