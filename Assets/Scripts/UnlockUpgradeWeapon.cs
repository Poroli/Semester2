using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockUpgradeWeapon : MonoBehaviour
{
	public Weapon_DMG Clicker;
	public Button UnlockButton;
	public int UnlockCost;

	private Money money;

	private void Start()
	{
		money = FindObjectOfType<Seele>();
	}

	public void Unlock()
	{
		money.RemovePoints(UnlockCost);
		Clicker.IsTicking = true;
	}

	private void Update()
	{
		if (money.CurrentPoints >= UnlockCost)
		{
			UnlockButton.interactable = true;
		}
		else
		{
			UnlockButton.interactable = false;
		}
	}
}
