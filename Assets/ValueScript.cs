using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ValueScript")]
public class ValueScript : ScriptableObject
{
    public float EnemyHealth;
    public float Weapon_baseDMG;
    public float Slide_Xtraspeed;
    public float MaxSlideStack;
    public int AirslideAmmount;
    public float AttackCooldown;
    public int Souls;
    public int Soulsperkill;
    public float PlayerMaxhealth;
    public float NormalEnemyDMG;
    public float[] AttackSpeedModifier;
    public int[] AttackSpeedCost;
    public float[] HealthModifier;
    public int[] HealthCost;
    public float[] SlideMeterModifier;
    public int[] SlideMeterCost;
    public float ActualSlideMeterModifier;
    public float ActualAttackSpeedModifier;
    public float ActualHealthModifier;
    public int AttackspeedModifierLevel;
    public int HealthModifierLevel;
    public int SlideMeterModifierLevel;
}