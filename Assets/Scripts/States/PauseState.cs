using UnityEngine;

public class PauseState : State
{
    public override void UpdateState()
    {
        base.UpdateState();
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.SwitchState<PlayingState>();
        }
    }
}
