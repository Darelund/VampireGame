using UnityEngine;
using UnityEngine.SceneManagement;

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
