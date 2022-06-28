using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Stats_Handler S_Handler;
    public ValueScript V_Script;
    public bool Attack = false;

    private Animator playerAnimator;
    private EnemyHealth E_Health;
    private bool attackoncooldown;

    private void Attackcooldown()
    {
        attackoncooldown = false;
    }

    void Start()
    {
        S_Handler = FindObjectOfType<Stats_Handler>();
        playerAnimator = FindObjectOfType<Animator>();
        E_Health = FindObjectOfType<EnemyHealth>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) == true && E_Health.schlagbar == true && attackoncooldown == false)
        {
            Attack = true;
            playerAnimator.SetTrigger("Attack");
            attackoncooldown = true;
            Invoke("Attackcooldown", V_Script.AttackCooldown);
        }
    }

}
