using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricWeapon : MeleeWeapon
{
   
    private float _distance = 1f;
    private float damageRadius = 3f;
    public override void Use()
    {
        if (GetWeaponOwner == CharacterType.NonPlayer)
        {
            if (Vector2.Distance(gameObject.transform.position, target.transform.position) < _distance)
            {
                var colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
              if(colliders.ToList().Exists(g => g.gameObject.name == "Player"))
                {
                    var playerCollider = colliders.ToList().Find(g => g.gameObject.name == "Player");
                    Debug.Log("electric shock");
                    var damageableObject = playerCollider.GetComponent<Damageable>();
                    damageableObject.TakeDamage(damage);
                    Instantiate(AttackProjectilePrefab, transform.position, Quaternion.identity);
                    canUse = false;
                }
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0) && GetWeaponOwner == CharacterType.Player)
        {
            //Should probably seperate Player and Enemy weapons, because this enum thing is weird
        }

    }
    public override void CreateAttackParticles()
    {

    }
}
