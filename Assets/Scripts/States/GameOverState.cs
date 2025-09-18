using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class GameOverState : State
{
    [SerializeField] private GameObject GameOverUI;

    public override void EnterState()
    {
        base.EnterState();
        GameOverUI.SetActive(true);
    }
    public override void UpdateState()
    {
        base.UpdateState();
       
    }
    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0); //0 Is the MainMenu, if I add an intro I might have to change this
    }
    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
