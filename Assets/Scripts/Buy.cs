using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    
    public ValueScript VS;
    public int ATSP = 0;
    public int H = 0;
    public int SM = 0;

    public void Start()
    {
        ATSP = VS.AttackspeedModifierLevel;
        H = VS.HealthModifierLevel;
        SM = VS.SlideMeterModifierLevel;
    }
    public void ATSPUP()
    {
        if (VS.Souls < VS.AttackSpeedCost[ATSP])
        {
            return;
        }
        else if (ATSP < VS.AttackSpeedCost.Length -1)
        {
           VS.Souls -= VS.AttackSpeedCost[ATSP];
            VS.ActualAttackSpeedModifier = VS.AttackSpeedModifier[ATSP];
           
            ATSP += 1;
        }

    }
    public void HUP()
    {
        if (VS.Souls < VS.HealthCost[H])
        {
            return;
        }
        else if (H < VS.HealthCost.Length -1)
        {
            VS.Souls -= VS.HealthCost[H];
            VS.ActualHealthModifier= VS.HealthModifier[H];
            H += 1;
        }

    }
    public void SMUP()
    {
        if (VS.Souls < VS.SlideMeterCost[SM])
        {
            return;
        }
        else if (SM < VS.SlideMeterCost.Length -1)
        {
               VS.Souls -= VS.SlideMeterCost[SM];
            VS.ActualSlideMeterModifier= VS.SlideMeterModifier[SM];
            SM += 1;
        }

    }
}
