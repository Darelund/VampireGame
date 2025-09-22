using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ProjectileManager projectileManager;
    public override void UpdateState()
    {
        base.UpdateState();
        enemySpawner.UpdateSpawner();

        controller.UpdatePlayer();
        enemyManager.UpdateAllEnemies();
        projectileManager.UpdateAllProjectiles();

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
