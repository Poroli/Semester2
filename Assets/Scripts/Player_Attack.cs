using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Damage_Handler DMGcalc;
    private Animator playerAnimator;

    public bool Attack = false;

    void Start()
    {
        DMGcalc = FindObjectOfType<Damage_Handler>();
        playerAnimator = FindObjectOfType<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Attack = true;
            playerAnimator.SetTrigger("Attack");
        }
    }

}
