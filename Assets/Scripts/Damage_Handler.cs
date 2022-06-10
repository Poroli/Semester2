using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Handler : MonoBehaviour
{

    public Player_Attack Pattack;
    public EnemyHealth E_Health;
    public float E_currentHealth;
    public float P_DMG;
    public float E_newcurrentHealth;
    

    private void Start()
    {
        Pattack = FindObjectOfType<Player_Attack>();
        E_Health = FindObjectOfType<EnemyHealth>();
    }

    //berechnung des final-DMG findet hier statt

}
