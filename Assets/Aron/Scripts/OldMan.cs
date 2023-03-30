using UnityEngine;

public class OldMan : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    public float maxDistance = 10f; // The maximum distance the character can move
    private Rigidbody2D rb; // The character's Rigidbody2D component
    private float distanceMoved = 0f; // The distance the character has moved so far

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void FixedUpdate()
    {
        // Move the character forward
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Keep track of how far the character has moved
        distanceMoved += Mathf.Abs(rb.velocity.x) * Time.fixedDeltaTime;

        // Stop the character if they have moved too far
        if (distanceMoved >= maxDistance)
        {
            rb.velocity = Vector2.zero; // Stop the character's movement
            enabled = false; // Disable this script so the character can't move anymore
        }
    }
}
