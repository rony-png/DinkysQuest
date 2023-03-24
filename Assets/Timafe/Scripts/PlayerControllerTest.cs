using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 10f;
    public float glideForce = 0.5f;

    public Animator animator;
    private bool isGrounded = false;
    private bool isGliding = false;
    private bool isAttacking = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite
        if (moveInput > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveInput < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        // Glide
        else if (Input.GetKey(KeyCode.Space) && !isGrounded && rb.velocity.y < 0f)
        {
            isGliding = true;
            rb.gravityScale = glideForce;
        }
        // Stop gliding
        else
        {
            isGliding = false;
            rb.gravityScale = 1f;
        }

        // Attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        // Update animator variables
        animator.SetBool("isIdle", moveInput == 0f);
        animator.SetBool("isWalking", moveInput != 0f && !isGliding);
        animator.SetBool("isSprinting", Input.GetKey(KeyCode.LeftShift) && moveInput != 0f && !isGliding);
        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isGliding", isGliding);
        animator.SetBool("isAttacking", isAttacking);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
