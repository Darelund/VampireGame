using UnityEngine;

public class RangeWeapon : BaseWeapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject AttackProjectilePrefab;

    [SerializeField] private Transform target; //Right now its the target of enemy movement... how to change


    protected void Start()
    {
        if (GetWeaponOwner == CharacterType.NonPlayer)
            target = GameManager.Instance.Player.transform;

        WeaponManager.Instance.GetWeapons.Add(gameObject);
    }


    public override void Use()
    {
        if (GetWeaponOwner == CharacterType.NonPlayer)
        {
            canUse = false;
            var dir = (target.position - transform.position);
            var normalizedDir = dir.normalized;
            var projectileObj = Instantiate(projectilePrefab, transform.position + normalizedDir * 2, Quaternion.identity);

            var projSpeed = 30;
            var projectile = projectileObj.GetComponent<Projectile>();
            projectile.Init(normalizedDir, projSpeed);
            projectileObj.layer = 7; //Magic number, just make sure the projectile is on EnemyProjectile layer, so we know that this specific bullet is supposed to damage the player
            ProjectileManager.Instance.GetProjectileList.Add(projectileObj);
           // CreateAttackParticles();
        }
        else if (Input.GetKey(KeyCode.Mouse0)  && GetWeaponOwner == CharacterType.Player)
        {
            canUse = false;
            var mouseInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseInWorldSpace.z = 0; //Ignore depth
            var dir = (mouseInWorldSpace - target.position);
            var normalizedDir = dir.normalized;
            var projectileObj = Instantiate(projectilePrefab, target.position, Quaternion.identity);

            var projSpeed = 30;
            var projectile = projectileObj.GetComponent<Projectile>();
            projectile.Init(normalizedDir, projSpeed);
            projectileObj.layer = 6;
            ProjectileManager.Instance.GetProjectileList.Add(projectileObj);
            CreateAttackParticles();
        }
    }
    private void CreateAttackParticles()
    {
        var attackObj = Instantiate(AttackProjectilePrefab, target.position, Quaternion.identity, target.transform);
    }
}
