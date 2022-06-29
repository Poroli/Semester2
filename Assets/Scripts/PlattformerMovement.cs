using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformerMovement : MonoBehaviour
{
    public ValueScript V_Script;
    public float MoveSpeed = 5f;
    public float JumpForce = 7f;
    public float Slidestartspeed;
    public float Slidetime;
    public float ActualSpeed;
    public bool sliding = false;
    public int slideDirectionVar;
    

    private Rigidbody2D rb2d;
    private Groundcheck groundCheck;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;
    private Stats_Handler S_Handler;
    private int canmove = 1;
    private int Slidetimeup = 1;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<Groundcheck>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
        S_Handler = FindObjectOfType<Stats_Handler>();

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

        if (Input.GetKey(KeyCode.LeftShift) && groundCheck.canAirslide())
        {
            canmove = 0;

            ActualSpeed = (slideDirectionVar * S_Handler.SlideSpeed) / Mathf.Pow(Slidetime, 2);
            if (Mathf.Abs(ActualSpeed) <= 1f || S_Handler.PercentageofMaxSlided >= 100)
            {
                ActualSpeed = 0;
                Slidetimeup = 0;
            }
            Slide.y = rb2d.velocity.y;
            Slide.x = ActualSpeed;
            Slidetime += Time.deltaTime * Slidetimeup;
            
            rb2d.velocity = Slide;
            sliding = true;


        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            groundCheck.Airslided();
            S_Handler.Percentagestack += S_Handler.PercentageofMaxSlided; 
            canmove = 1;
            Slidetime = 1f;
            S_Handler.Slidedistance = 0;
            Slidetimeup = 1;
            sliding = false;
            S_Handler.CanGetSpeed = true;
            S_Handler.Slidetimereset = 0;
        }
    }

    private void SetAnimations(Vector2 velocity, bool justJumped)
    {
        playerAnimator.SetBool("IsGrounded", groundCheck.Grounded);

        if (velocity.magnitude > 0)
        {
           playerAnimator.SetBool("Moves", true);
            if (velocity.x > 0)
            {
                playerRenderer.flipX = false;
                slideDirectionVar = 1;

            }
            else if (velocity.x < 0)
            {
                playerRenderer.flipX = true;
                slideDirectionVar = -1;
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
        else if (sliding == true)
        {
            playerAnimator.SetTrigger("Slide");
        }
    }
}
