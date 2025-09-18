using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private EnemySpawner enemySpawner;
    public override void UpdateState()
    {
        base.UpdateState();
        enemySpawner.UpdateSpawner();

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
