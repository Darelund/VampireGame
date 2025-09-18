using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private float currentCooldownTimer;

    [SerializeField] private bool canShoot;

    [SerializeField] private EnemyMovement enemyMovement;

    public void UpdateShooting()
    {
        if (canShoot)
        {
            Shoot();
        }
        else
        {
            currentCooldownTimer += Time.deltaTime;
            if (currentCooldownTimer > cooldown)
            {
                canShoot = true;
                currentCooldownTimer = 0;
            }
        }
    }


    private void Shoot()
    {
        canShoot = false;
        var dir = (enemyMovement.target.transform.position - transform.position);
        var normalizedDir = dir.normalized;
        var projectileObj = Instantiate(projectilePrefab, transform.position + normalizedDir * 2, Quaternion.identity);

        var projSpeed = 30;
        projectileObj.GetComponent<Projectile>().Init(normalizedDir, projSpeed);
    }
}
