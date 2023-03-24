using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 10f;
    public float glideForce = 0.5f;
    public Animator animator;

    private bool isGrounded = false;
    private bool isGliding = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite based on movement
        if (moveInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0f)
        {
            spriteRenderer.flipX = true;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump");
        }
        // Glide
        else if (Input.GetKey(KeyCode.Space) && !isGrounded && rb.velocity.y < 0f)
        {
            isGliding = true;
            rb.gravityScale = glideForce;
            animator.SetBool("IsGliding", true);
        }
        // Stop gliding
        else
        {
            isGliding = false;
            rb.gravityScale = 1f;
            animator.SetBool("IsGliding", false);
        }

        // Set animation speed based on movement
        float absSpeed = Mathf.Abs(moveInput * moveSpeed);
        animator.SetFloat("Speed", absSpeed);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsSprinting", Input.GetKey(KeyCode.LeftShift));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
