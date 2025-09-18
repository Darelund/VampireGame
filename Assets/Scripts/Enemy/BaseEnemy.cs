using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyShooter enemyShooter;

    public void UpdateEnemy()
    {
        enemyMovement.UpdateMovement();
        enemyShooter.UpdateShooting();
    }
}
