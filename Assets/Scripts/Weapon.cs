using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Damage_Handler DMGcalc;
    public ValueScript VScript;
    public bool InReichweite = false;
    public float weapon_DMG;

    private void Start()
    {
        DMGcalc = FindObjectOfType<Damage_Handler>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            InReichweite = true;
            DMGcalc.P_DMG = weapon_DMG;
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
