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
                var playerCollider = Physics2D.OverlapCircleAll(transform.position, damageRadius);
              if(playerCollider.ToList().Exists(g => g.gameObject.name == "Player"))
                {

                    Debug.Log("electric shock");
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
