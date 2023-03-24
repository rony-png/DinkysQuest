using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrollertest : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the player moves
    public float jumpForce = 10f; // force applied to the player when jumping

    private Rigidbody2D rb; // reference to the Rigidbody2D component
    private Animator animator; // reference to the Animator component
    private bool isGrounded; // whether or not the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // move the player left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        // allow the player to jump if they are on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // set the animator parameters based on the player's movement
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("IsGrounded", isGrounded);

        // flip the player sprite based on their direction
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
