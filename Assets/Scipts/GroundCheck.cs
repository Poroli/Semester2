using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject Origin;
    public float Distance;
    public LayerMask GroundLayer;

    public bool IsGrounded;

    public int JumpAmount;

    private int currentJumpCount;
    private bool isOnCooldown;



    private void EndCooldown()
    {
        isOnCooldown = false;
    }

    private void Update()
    {
        if (isOnCooldown == true)
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(Origin.transform.position, Vector2.down, Distance, GroundLayer);

        if (hit.collider == null) 
        {
            IsGrounded = false;
            if(currentJumpCount <= 0)
            {
                currentJumpCount += 1;
            }
        }   
        else
        {
            IsGrounded = true;
            currentJumpCount = 0;
        }
    }

    public bool CanJump()
    {
        if (currentJumpCount < JumpAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        
    public void JustJumped()
    {
        currentJumpCount += 1;
        isOnCooldown = true;
        IsGrounded = false;
        Invoke("EndCooldown", 0.2f);
    }


}
