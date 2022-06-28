using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public ValueScript V_Script;
    public float currenthealth;

    void Start()
    {
        currenthealth = V_Script.PlayerMaxhealth;
    }

    void Update()
    {
        
    }
}
