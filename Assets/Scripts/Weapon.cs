using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Damage_Handler DMG_Handler;
    public ValueScript VScript;
    public bool InReichweite = false;
    public float weapon_DMG;

    private void Start()
    {
        DMG_Handler = FindObjectOfType<Damage_Handler>();
        weapon_DMG = VScript.Weapon_baseDMG;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            InReichweite = true;
            DMG_Handler.P_DMG = weapon_DMG;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            InReichweite = false;
        }
    }
}
