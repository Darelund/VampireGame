using System.Collections.Generic;
using UnityEngine;

public class ChangeAbilityUpgrade : Upgrade
{
    public string _upgrade;

    private PlayerUpgrade playerUpgrade;
    public override void Awake()
    {
        base.Awake();
        playerUpgrade = GameObject.FindAnyObjectByType<PlayerUpgrade>();
    }



    public override void ActivateAbility()
    {
       string classToUpgrade = playerUpgrade.abilityUpgrades[_upgrade].Item1;
        if(classToUpgrade == null)
        {
            Debug.Log("Why am I null?");
            return;
        }
        if(classToUpgrade == "PlayerMovement")
        {
            if (_upgrade == "dash")
            {
                //playerController.GetPlayerMovement.
                //Not implemented
            }
            else if (_upgrade == "dodge")
            {
                //Not implemented
            }
            else if (_upgrade.Remove(5) == "speed")
            {
                playerController.GetPlayerMovement.ChangeMoveSpeed((float)playerUpgrade.abilityUpgrades[_upgrade].Item2);
                playerController.GetPlayerMovement.ChangeMoveSpeed((float)playerUpgrade.abilityUpgrades[_upgrade].Item2 + 10);
            }
        }
        if (classToUpgrade == "PlayerHealth")
        {
            playerController.GetPlayerHealth.SetmaxHealth((float)playerUpgrade.abilityUpgrades[_upgrade].Item2);
        }
        GameManager.Instance.SwitchState<PlayingState>();
    }
}
//public enum UpgradeType
//{

//}
