using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Handler : MonoBehaviour
{

    public Player_Attack Pattack;
    public EnemyHealth E_Health;
    public PlattformerMovement P_Movement;
    public float Weapon_DMG;
    public float Player_DMG;
    public float SlideSpeed;
    public float S_StartSpeedUpgrade;
    public float Slidedistance;
    public float roundedSlidedistance;
    public float Slidetimereset = 0;
    public int PercentageofMaxSlided;

    public bool Chicken = true;
    

    private void Start()
    {
        Pattack = FindObjectOfType<Player_Attack>();
        E_Health = FindObjectOfType<EnemyHealth>();
        P_Movement = FindObjectOfType<PlattformerMovement>();
    }

    //berechnung des final-DMG findet hier statt
    private void Update()
    {
        Slidedistance += P_Movement.ActualSpeed * (P_Movement.Slidetime - 1);
        roundedSlidedistance = Mathf.RoundToInt(Slidedistance);
        
    }

    //Berechnung Der Stats für Slide

    private void FixedUpdate()
    {
        if (P_Movement.sliding == true && Chicken == true)
        {
            Slidetimereset = Mathf.Sqrt(Mathf.Abs(P_Movement.ActualSpeed / P_Movement.Slidetime));
            Chicken = false;
        }
        SlideSpeed = Mathf.Abs(P_Movement.Slidestartspeed) + S_StartSpeedUpgrade;
        Player_DMG = Weapon_DMG * Mathf.Abs(roundedSlidedistance);

        PercentageofMaxSlided = Mathf.RoundToInt(((10 * P_Movement.Slidetime) / (10 * Slidetimereset)) * 100);

    }
}
