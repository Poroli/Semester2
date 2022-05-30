using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 7f;

    private Rigidbody2D rigidbody;
    private GroundCheck groundCheck;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        bool justJumped = false;
        Vector2 newVelocity = new Vector2();
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        newVelocity.x = horizontalInput * MoveSpeed;
        newVelocity.y = rigidbody.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.CanJump())
        {
            newVelocity.y = JumpForce;
            groundCheck.JustJumped();
            justJumped = true;
        }

        rigidbody.velocity = newVelocity;
        SetAnimations(newVelocity, justJumped);
    }

    private void SetAnimations(Vector2 velocity, bool justJumped)
    {
        playerAnimator.SetBool("IsGrounded", groundCheck.IsGrounded);

        if (velocity.magnitude > 0.05)
        {
           playerAnimator.SetBool("IsMoving", true);
            if (velocity.x > 0)
            {
                playerRenderer.flipX = false;
            }
            else if (velocity.x < 0)
            {
                playerRenderer.flipX = true;
            }
        }
        else
        {
            playerAnimator.SetBool("IsMoving", false);
        }

        if (justJumped == true)
        {
            playerAnimator.SetTrigger("Jump");
        }
    }
}
