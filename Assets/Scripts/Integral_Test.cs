using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integral_Test : MonoBehaviour
{
    public Stats_Handler S_Handler;
    public PlattformerMovement P_Movement;

    public float Integralende;
    public float Integralbeginn;
    public int h;

    private void Start()
    {
        S_Handler = FindObjectOfType<Stats_Handler>();
        P_Movement = FindObjectOfType<PlattformerMovement>();
    }
    private void FixedUpdate()
    {
        Banane();
        float Banane()
        {

            float xp, ActualSpeed, s, result = 0, Intergralbereich = (Integralende - Integralbeginn) / h;
            for (int i = 0; i < h; i++)
            {
                xp = Integralbeginn + Intergralbereich;
                ActualSpeed = S_Handler.SlideSpeed / Mathf.Pow(P_Movement.Slidetime, 2);
                s = Intergralbereich * ActualSpeed;
                result += s;
            }
            Debug.Log(result);
            return result;
        }

    }
}