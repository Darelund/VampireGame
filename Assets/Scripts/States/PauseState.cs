using UnityEngine;

public class PauseState : State
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private ProjectileManager projectileManager;
    public override void EnterState()
    {
        pauseUI.SetActive(true);
        projectileManager.ToggleSimulationForProjectiles(false);
    }
   
    public override void UpdateState()
    {
        base.UpdateState();
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.SwitchState<PlayingState>();
        }
    }
    public override void ExitState()
    {
        pauseUI.SetActive(false);
        projectileManager.ToggleSimulationForProjectiles(true);
    }
}
