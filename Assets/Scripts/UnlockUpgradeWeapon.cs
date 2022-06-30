using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnlockUpgradeWeapon : MonoBehaviour
{
	public Stats_Handler s_handler;
	public ValueScript v_script;

	public void Max_Health()
	{
		
	}

	public void Max_Slide_Meter()
	{

	}

	public void Max_Attack_Speed()
	{

	}
    private void Start()
    {
        s_handler = FindObjectOfType<Stats_Handler>();
		
    }
}
