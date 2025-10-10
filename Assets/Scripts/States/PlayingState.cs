using UnityEngine;

public class PlayingState : State
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private ProjectileManager projectileManager;
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private ObjectPoolManager objectPoolManager;

    public override void EnterState()
    {
        objectPoolManager.InitializeAllPooles();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        waveManager.UpdateWave();

        controller.UpdatePlayer();

        enemyManager.UpdateAllEnemies();
        projectileManager.UpdateAllProjectiles();

        weaponManager.UpdateAllWeapons();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.SwitchState<PauseState>();
        }
    }
    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
    public override void LateUpdateState()
    {
        controller.LateUpdatePlayer();
    }
}
