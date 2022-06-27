using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Handler : MonoBehaviour
{
    
    
    public Player_Attack Pattack;
    public EnemyHealth E_Health;
    public PlattformerMovement P_Movement;
    public ValueScript V_Script;
    public float Weapon_DMG;
    public float Player_DMG;
    public float SlideSpeed;
    public float Slide_SpeedUpgrade;
    public float Slidedistance;
    public float roundedSlidedistance;
    public float Slidetimereset = 0;
    public int PercentageofMaxSlided;
    public bool CanGetSpeed = true;
    public float Percentagestack;

    private float Slide_Xtrastartspeed;

    private void Start()
    {
        Pattack = FindObjectOfType<Player_Attack>();
        E_Health = FindObjectOfType<EnemyHealth>();
        P_Movement = FindObjectOfType<PlattformerMovement>();
        Slide_Xtrastartspeed = V_Script.Slide_Xtraspeed;
    }

    //berechnung des final-DMG findet hier statt
    private void Update()
    {
        Slidedistance += P_Movement.ActualSpeed * (P_Movement.Slidetime - 1);
        roundedSlidedistance = Mathf.RoundToInt(Slidedistance);

        if (Percentagestack >= V_Script.MaxSlideStack)
        {
            Percentagestack = V_Script.MaxSlideStack;
        }
    }

    //Berechnung Der Stats für Slide

    private void FixedUpdate()
    {
        if (P_Movement.sliding == true && CanGetSpeed == true)
        {
            Slidetimereset = Mathf.Sqrt(Mathf.Abs(P_Movement.ActualSpeed / P_Movement.Slidetime));
            CanGetSpeed = false;
        }
        SlideSpeed = Mathf.Abs(P_Movement.Slidestartspeed) + Slide_SpeedUpgrade + Slide_Xtrastartspeed;
        Player_DMG = Weapon_DMG + (Weapon_DMG * PercentageofMaxSlided);

        PercentageofMaxSlided = Mathf.RoundToInt(((10 * P_Movement.Slidetime) / (10 * Slidetimereset)) * 100);
    }
}
