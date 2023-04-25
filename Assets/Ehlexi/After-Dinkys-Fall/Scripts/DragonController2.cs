using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Sprites;
using System.Collections;
using System.Collections.Generic;
public class DragonController2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Animator animator;
    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool isGrounded;
    public bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
            isWalking = true;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
            isWalking = true;
            sprite.flipX = false;
        }
        else
        {
            isWalking = false;
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);

        // Attacking
        if (Input.GetKeyDown(KeyCode.Mouse0)) ;
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
