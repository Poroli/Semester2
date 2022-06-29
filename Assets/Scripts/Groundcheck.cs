using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public GameObject Origin;
    public LayerMask GroundLayer;
    public ValueScript VScript;
    public float Distance;
    public int JumpAmmount;
    public bool Grounded;
    public float Cooldown;
    public GameObject StandardCollider;
    public GameObject JumpCollider;

    private int jumpCount;
    private bool isOnCooldown;
    private int slideCount;
    private int slideAmmount;

    private void Start()
    {
        slideAmmount = VScript.AirslideAmmount;
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
            Grounded = false;
            if (jumpCount <= 0)
            {
                jumpCount += 1;
            }
        }
        else
        {
            Grounded=true;
            //StandCollider an
            StandardCollider.gameObject.SetActive(true);
            //JumpCollider aus
            JumpCollider.gameObject.SetActive(false);
            jumpCount = 0;
        }
        
        if (hit.collider == null)
        {
            if (slideCount <= 0)
            {
                slideCount += 1;
            }
        }
        else 
        { 
            slideCount = 0;
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

    public bool canAirslide()
    {
        if (slideCount < slideAmmount)
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
        //JumpCollider an
        JumpCollider.gameObject.SetActive(true);
        //StandardCollider aus
        StandardCollider.gameObject.SetActive(false);
        jumpCount += 1;
        isOnCooldown = true;
        Grounded = false;
        Invoke("EndCooldown", Cooldown);
    }
    public void Airslided()
    {
        slideCount += 1;
    }

    private void EndCooldown()
    {
        isOnCooldown = false;
    }
}
