using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main_Menu_Upgrades_UI_Updater : MonoBehaviour
{
    public TMP_Text Souls;
    public ValueScript V_Script;

    void Update()
    {
        Souls.text = V_Script.Souls.ToString();    
    }
}
