using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private float currentCooldownTimer;

    [SerializeField] private bool canShoot;

    [SerializeField] private GameObject AttackPrefab;
    [SerializeField] private Transform attackPosition;




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
        if(Input.GetKey(KeyCode.Mouse0))
        {
            ShootProjectile();
            CreateAttackParticles();
        }
    }
    private void ShootProjectile()
    {
        canShoot = false;
        var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInWorldSpace.z = 0; //Ignore depth
        var dir = (mouseInWorldSpace - attackPosition.position);
        var normalizedDir = dir.normalized;
        var projectileObj = Instantiate(projectilePrefab, attackPosition.position, Quaternion.identity);

        var projSpeed = 30;
        var projectile = projectileObj.GetComponent<Projectile>();
        projectile.Init(normalizedDir, projSpeed);
        projectileObj.layer = 6;
        ProjectileManager.Instance.GetProjectileList.Add(projectileObj);
    }
    private void CreateAttackParticles()
    {
        var attackObj = Instantiate(AttackPrefab, attackPosition.position, Quaternion.identity, attackPosition);
    }
}
