using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private EnemyManager enemyManager;
    public override void UpdateState()
    {
        base.UpdateState();
        controller.UpdatePlayer();
        enemyManager.UpdateAllEnemies();

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
