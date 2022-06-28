using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ValueScript")]
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
}