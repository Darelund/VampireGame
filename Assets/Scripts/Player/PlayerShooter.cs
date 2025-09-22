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
        var dir = (mouseInWorldSpace - transform.position);
        var normalizedDir = dir.normalized;
        var projectileObj = Instantiate(projectilePrefab, transform.position + normalizedDir * 2, Quaternion.identity);

        var projSpeed = 30;
        projectileObj.GetComponent<Projectile>().Init(normalizedDir, projSpeed);
        ProjectileManager.Instance.GetProjectileList.Add(projectileObj);
    }
    private void CreateAttackParticles()
    {
        var attackObj = Instantiate(AttackPrefab, attackPosition.position, Quaternion.identity);
        attackObj.transform.SetParent(transform.GetChild(1));
        //attackObj.transform.position = Vector2.zero;
    }
}
