using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public GameObject Origin;
    public LayerMask GroundLayer;
    public float Distance;
    public int JumpAmmount;
    public bool Grounded;
    public float Cooldown;
    
    private int jumpCount;
    private bool isOnCooldown;



    private void Update()
    {
        if (isOnCooldown == true)
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(Origin.transform.position, Vector2.down, Distance, GroundLayer);

        if (hit.collider == null)
        {
            Grounded = false;
            if (jumpCount <= 0)
            {
                jumpCount += 1;
            }
        }
        else
        {
            Grounded=true;
            jumpCount = 0;
        }
    }
    public bool CanJump()
    {
        if (jumpCount < JumpAmmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Jumped()
    {
        jumpCount += 1;
        isOnCooldown = true;
        Grounded = false;
        Invoke("EndCooldown", Cooldown);
    }

    private void EndCooldown()
    {
        isOnCooldown = false;
    }
}
