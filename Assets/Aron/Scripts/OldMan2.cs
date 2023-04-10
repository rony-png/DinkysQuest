using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan2 : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    public float maxDistance = 10f; // The maximum distance the character can move
    public float animDistance = 7f; // The distance at which the new animation plays
    public Animator animator; // The animator component for the character's animations
private Rigidbody2D rb; // The character's Rigidbody2D component
    private float distanceMoved = 0f; // The distance the character has moved so far
    private bool isPlayingAnimation = false; // Flag to track if the new animation is playing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void FixedUpdate()
    {
        // Move the character forward
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Keep track of how far the character has moved
        distanceMoved += Mathf.Abs(rb.velocity.x) * Time.fixedDeltaTime;

        // Check if the character has moved far enough to trigger the new animation
        if (distanceMoved >= animDistance && !isPlayingAnimation)
        {
            isPlayingAnimation = true; // Set the flag to true

            // Trigger the new animation
            animator.SetTrigger("NewAnimation");

            // Stop the character's movement while the animation plays
            rb.velocity = Vector2.zero;
        }

        // Check if the new animation has finished playing
        if (isPlayingAnimation && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            isPlayingAnimation = false; // Reset the flag

            // Resume the character's movement
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        // Stop the character if they have moved too far
        if (distanceMoved >= maxDistance)
        {
            rb.velocity = Vector2.zero; // Stop the character's movement
            enabled = false; // Disable this script so the character can't move anymore
        }
    }
}