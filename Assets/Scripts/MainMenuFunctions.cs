using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public GameObject PlayUntermenü;
    
    public void Play()
    {
        PlayUntermenü.SetActive(true);
    }

    public void PlayTutorialYes()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayTutorialNo()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        
    }
}
