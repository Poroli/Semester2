using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public  ValueScript V_Script;
    public Stats_Handler S_Handler;
    public Player_Attack Pattack;


 
    public float currentHealth;
    public float newcurrentHealth;
    public bool schlagbar = false;

    private void Start()
    {
        S_Handler = FindObjectOfType<Stats_Handler>();
        Pattack = FindObjectOfType<Player_Attack>();
        currentHealth = V_Script.EnemyHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Debug.Log("Affe");
            schlagbar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        schlagbar = false;
    }
    private void Update()
    {
        if (Pattack.Attack == true && schlagbar == true)
        {
            newcurrentHealth = currentHealth - S_Handler.Player_DMG;
            Pattack.Attack = false;
            currentHealth = newcurrentHealth;
            S_Handler.Percentagestack = 0;
        }
        if (currentHealth <= 0)
        {
            //EnemyDeathAnimation einf?gen
            gameObject.SetActive(false);
            V_Script.Souls += V_Script.Soulsperkill;
        }
    }
}
