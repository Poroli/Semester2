using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MSpeed;
    public float Jumpforce;
    
    private Rigidbody2D rigidbody;
    private Groundcheck groundcheck;
    private SpriteRenderer richtung;
    private Animator playerAnimator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        groundcheck = GetComponent<Groundcheck>();
        playerAnimator = GetComponentInChildren<Animator>();
        richtung =  GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 Direction;
        bool Jumped = false;
       
        float horizontalinput = Input.GetAxis("Horizontal");

        Direction.x = horizontalinput * MSpeed;
        Direction.y = rigidbody.velocity.y;

       
        if (Input.GetKeyDown(KeyCode.Space) && groundcheck.CanJump())
        {
            Direction.y = Jumpforce;
            groundcheck.Jumped();
            Jumped = true;
        }


        rigidbody.velocity = Direction;
        SetAnimations(Direction, Jumped);
        Blickrichtung();
    }

    private void SetAnimations(Vector2 Direction, bool Jumped)
    {
        playerAnimator.SetBool("IsGrounded", groundcheck.Grounded);
        if (Jumped == true)
        {
            playerAnimator.SetTrigger("Jump");
        }
        else if (Direction.magnitude > 0)
        {
            playerAnimator.SetBool("Moves", true);
        }
        else
        {
            playerAnimator.SetBool("Moves", false);
        }
    }
    private void Blickrichtung()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            richtung.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            richtung.flipX = false;
        }
    }
}
