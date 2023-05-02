using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinkyFallingAnim : MonoBehaviour
{
    public float distance = 5f;         // distance to move
    public float pauseTime = 1f;        // time to pause in the air
    public float fallSpeed = 5f;        // speed at which object falls
    public float startDelay = 2f;       // time to wait before starting movement
    public Animator anim;              // animator component for animation playback

    private Vector2 startPosition;     // starting position of object
    private Vector2 targetPosition;    // target position of object
    private bool movingRight = true;   // direction of movement
    private bool isPaused = false;     // flag to indicate if object is paused in air
    private bool isWaiting = true;     // flag to indicate if object is waiting to start movement
    private float waitTime = 0f;       // time object has been waiting

    // Start is called before the first frame update
    void Start()
    {
        // get starting position
        startPosition = transform.position;

        // calculate target position based on distance to move
        targetPosition = new Vector2(startPosition.x + distance, startPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            // increment wait time
            waitTime += Time.deltaTime;

            // check if wait time has elapsed
            if (waitTime >= startDelay)
            {
                // reset wait time
                waitTime = 0f;

                // start movement
                isWaiting = false;
            }
        }
        else
        {
            // check if object is currently paused in air
            if (isPaused)
            {
                // wait for pauseTime seconds before resuming movement
                StartCoroutine(WaitForPause());
            }
            else
            {
                // move object towards target position
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * fallSpeed);

                // check if object has reached target position
                if (transform.position.x == targetPosition.x)
                {
                    // flip direction of movement
                    movingRight = !movingRight;

                    // pause object in air for pauseTime seconds
                    isPaused = true;

                    // play animation
                    anim.SetTrigger("StartFalling");
                }
            }
        }
    }

    IEnumerator WaitForPause()
    {
        // wait for pauseTime seconds
        yield return new WaitForSeconds(pauseTime);

        // reset flag
        isPaused = false;

        // update target position based on new direction of movement
        if (movingRight)
        {
            targetPosition = new Vector2(startPosition.x + distance, startPosition.y);
        }
        else
        {
            targetPosition = new Vector2(startPosition.x, startPosition.y);
        }
    }
}
