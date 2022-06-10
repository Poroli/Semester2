using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public  ValueScript VScript;
    public Damage_Handler DMGcalc;
    public Player_Attack Pattack;


 
    public float currentHealth;
    public float newcurrentHealth;
    public bool schlagbar = false;

    private void Start()
    {
        DMGcalc = FindObjectOfType<Damage_Handler>();
        Pattack = FindObjectOfType<Player_Attack>();
        currentHealth = VScript.EnemyHealth;
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
        if (currentHealth <= 0)
        {
            //EnemyDeathAnimation einfügen
            gameObject.SetActive(false);
        }
        if (schlagbar == true)
        {
            DMGcalc.E_currentHealth = currentHealth;
        }
        if (Pattack.Attack == true && schlagbar == true)
        {
            newcurrentHealth = currentHealth - DMGcalc.P_DMG;
            Pattack.Attack = false;
            currentHealth = newcurrentHealth;
        }
    }
}
