using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    [SerializeField] protected Transform target;
    protected void Start()
    {
        if (GetWeaponOwner == CharacterType.NonPlayer)
            target = GameManager.Instance.Player.transform;

        //WeaponManager.Instance.GetWeapons.Add(gameObject);
    }

    public override void Use()
    {
       //Do whatever

    }
    public override void CreateAttackParticles()
    {

    }
}
