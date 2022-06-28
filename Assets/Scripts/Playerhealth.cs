using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (currenthealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
