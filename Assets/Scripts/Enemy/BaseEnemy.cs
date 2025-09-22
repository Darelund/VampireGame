using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyShooter enemyShooter;
    [SerializeField] private EnemyHealth enemyHealth;

    public void UpdateEnemy()
    {
        if (!enemyHealth.IsAlive) return;
        enemyMovement.UpdateMovement();
        enemyShooter.UpdateShooting();
    }
}
