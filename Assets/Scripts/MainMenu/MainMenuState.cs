using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuState : State
{
   
    public void StartGame()
    {
        SceneManager.LoadScene(1); // One being the first scene
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
