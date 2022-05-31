using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 7f;
    public float Slidestartspeed;
    public float Slidetime;
    public float ActualSpeed;

    private Rigidbody2D rb2d;
    private Groundcheck groundCheck;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;
    private int canmove = 1;
    private bool sliding = false;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<Groundcheck>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();

        Slidestartspeed = 0;
        Slidetime = 1f;
    }

    private void Update()
    {
        bool justJumped = false;
        Vector2 newVelocity = new Vector2();
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (canmove == 1)
        {
            newVelocity.x = horizontalInput * MoveSpeed;
        }
        newVelocity.y = rb2d.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.CanJump())
        {
            newVelocity.y = JumpForce;
            groundCheck.Jumped();
            justJumped = true;
        }
        
        rb2d.velocity = newVelocity;
        SetAnimations(newVelocity, justJumped);

        Slidestartspeed = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        Vector2 Slide = new Vector2 ();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            canmove = 0;
            
            ActualSpeed = Slidestartspeed / (Slidetime * Slidetime);
            if (Mathf.Abs(ActualSpeed) <= 1f )
            {
                ActualSpeed = 0;
            }
            Slide.y = rb2d.velocity.y;
            Slide.x = ActualSpeed;
            Slidetime += Time.deltaTime;
            
            rb2d.velocity = Slide;
            sliding = true;


        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canmove = 1;
            Slidetime = 1f;
            sliding = false;
        }
    }

    private void SetAnimations(Vector2 velocity, bool justJumped)
    {
        playerAnimator.SetBool("IsGrounded", groundCheck.Grounded);

        if (velocity.magnitude > 0.05)
        {
           playerAnimator.SetBool("Moves", true);
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
            playerAnimator.SetBool("Moves", false);
        }

        if (justJumped == true)
        {
            playerAnimator.SetTrigger("Jump");
        }
    }
}
