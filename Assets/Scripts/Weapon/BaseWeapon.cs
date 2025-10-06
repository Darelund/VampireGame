using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    [SerializeField] protected float currentCooldownTimer;
    [SerializeField] protected bool canUse;
    [SerializeField] private CharacterType weaponOwner;
    public CharacterType GetWeaponOwner => weaponOwner;

    
    public virtual void UpdateWeapon()
    {
        //if (canUse)
        //{
        //    Use();
        //}
        //else
        //{
        //    currentCooldownTimer += Time.deltaTime;
        //    if (currentCooldownTimer > cooldown)
        //    {
        //        canUse = true;
        //        currentCooldownTimer = 0;
        //    }
        //}

        if (!canUse)
        {
            currentCooldownTimer += Time.deltaTime;
            if (currentCooldownTimer > cooldown)
            {
                canUse = true;
                currentCooldownTimer = 0;
            }
            return;
        }
        Use();
    }


    public abstract void Use();
    public abstract void CreateAttackParticles();


}
