using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Stats_Handler DMG_Handler;
    private Animator playerAnimator;
    private EnemyHealth E_Health;

    public bool Attack = false;

    void Start()
    {
        DMG_Handler = FindObjectOfType<Stats_Handler>();
        playerAnimator = FindObjectOfType<Animator>();
        E_Health = FindObjectOfType<EnemyHealth>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) == true && E_Health.schlagbar == true)
        {
            Attack = true;
            playerAnimator.SetTrigger("Attack");
        }
    }

}
