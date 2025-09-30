using System.Collections.Generic;
using UnityEngine;

public class ChangeAbilityUpgrade : Upgrade
{
    public PlayerStat stat;
    public string _upgrade;
    private PlayerUpgrade playerUpgrade;

    public override void Awake()
    {
        base.Awake();
        playerUpgrade = GameObject.FindAnyObjectByType<PlayerUpgrade>();

    }



    public override void ActivateAbility()
    {
        playerUpgrade.abilityUpgrades[_upgrade] = stat;
        GameManager.Instance.SwitchState<PlayingState>();
    }
}
