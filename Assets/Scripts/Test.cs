using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ValueScript DataContainer;

	private void Start()
	{
		Debug.Log(DataContainer.DropChance);
	}
}
