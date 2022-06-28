using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Updater : MonoBehaviour
{
    public TMP_Text Souls;
    public ValueScript V_Script;
    public Image Healthbar;
    public Image Attackbar;

    private Playerhealth P_health;
    private Stats_Handler S_Handler;

    private void Start()
    {
        P_health = FindObjectOfType<Playerhealth>();
        S_Handler = FindObjectOfType<Stats_Handler>();
    }

    void Update()
    {
        Souls.text = V_Script.Souls.ToString();
        Healthbar.fillAmount = P_health.currenthealth / V_Script.PlayerMaxhealth;
        Attackbar.fillAmount = S_Handler.Percentagestack / V_Script.MaxSlideStack;
    }
}
