using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan2 : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    public float maxDistance = 10f; // The maximum distance the character can move
    public float animDistance = 7f; // The distance at which the new animation plays
    public float stopTime = 2f; // The time in seconds the character stops moving after reaching the animDistance
    public Animator animator; // The animator component for the character's animations
    private Rigidbody2D rb; // The character's Rigidbody2D component
    private float distanceMoved = 0f; // The distance the character has moved so far
    private bool isPlayingAnimation = false; // Flag to track if a new animation is playing
    private float timeSinceStopped = 0f; // The time since the character stopped moving
    private bool hasPlayedThirdAnimation = false; // Flag to track if the third animation has been played

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void FixedUpdate()
    {
        // Move the character forward if they are not stopped
        if (timeSinceStopped <= 0f && !hasPlayedThirdAnimation)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
            timeSinceStopped -= Time.fixedDeltaTime;
        }

        // Keep track of how far the character has moved
        distanceMoved += Mathf.Abs(rb.velocity.x) * Time.fixedDeltaTime;

        // Check if the character has moved far enough to trigger a new animation
        if (distanceMoved >= animDistance && !isPlayingAnimation && !hasPlayedThirdAnimation)
        {
            isPlayingAnimation = true; // Set the flag to true

            // Trigger the new animation
            animator.SetTrigger("NewAnimation");

            // Stop the character's movement while the animation plays
            rb.velocity = Vector2.zero;

            // Start the timer to resume movement
            timeSinceStopped = stopTime;
        }

        // Check if the new animation has finished playing
        if (isPlayingAnimation && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            isPlayingAnimation = false; // Reset the flag

            // Resume the character's movement
            timeSinceStopped = 0f;
            if (!hasPlayedThirdAnimation)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }

        // Check if the character has reached the maximum distance and the third animation hasn't been played
        if (distanceMoved >= maxDistance && !hasPlayedThirdAnimation)
        {
            // Trigger the third new animation
            animator.SetTrigger("ThirdAnimation");

            // Stop the character's movement
            rb.velocity = Vector2.zero;

            // Set the flag to indicate that the third animation has been played
            hasPlayedThirdAnimation = true;
        }
    }
}
