using UnityEngine;

public class AddAbilityUpgrade : Upgrade
{
    public GameObject NewAbilityPrefab;
  
    public override void Awake()
    {
        base.Awake();
    }
    public override void ActivateAbility()
    {
        Instantiate(NewAbilityPrefab, playerController.transform);
        GameManager.Instance.SwitchState<PlayingState>();
        Debug.Log("Added ability");

    }
}

public class AddProjectileUpgrade : Upgrade
{
    public override void ActivateAbility()
    {
       
    }
}
public class AddWeaponUpgrade : Upgrade
{
    //We need get a reference to the weapon of the player
    public override void ActivateAbility()
    {
       //Change x value
    }
}
//weapon (damage, colldown)
//projectiles
//sword
// gun