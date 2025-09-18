using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private PlayerController controller;
    public override void UpdateState()
    {
        base.UpdateState();
        controller.UpdatePlayer();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.SwitchState<PauseState>();
        }
    }
    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

    }
}
