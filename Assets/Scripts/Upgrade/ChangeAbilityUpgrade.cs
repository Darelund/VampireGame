using System.Collections.Generic;
using UnityEngine;

public class ChangeAbilityUpgrade : Upgrade
{
    private ChangeUpgradeSO _changeUpgradeSO;
    public ChangeUpgradeSO ChangeUpgradeSO
    {
        get => _changeUpgradeSO;
        set => _changeUpgradeSO = value;
    }
    [SerializeField] private PlayerUpgrade playerUpgrade;

    public override void Awake()
    {
        base.Awake();
        playerUpgrade = GameObject.FindAnyObjectByType<PlayerUpgrade>();
    }

    public override void ActivateAbility()
    {
        playerUpgrade.AbilityUpgrades[_changeUpgradeSO.ChangeAbilityType.ToString()] = _changeUpgradeSO.playerStat;
        playerUpgrade.FireChangeAbility();

        //TODO: Also here, quick solution to make this Upgrades "work" temporarily, fix later
        if(ChangeUpgradeSO.ChangeAbilityType == ChangeAbilityType.Health)
        {
            playerUpgrade.currentPlayerStats.CurrentHealthLevel = _changeUpgradeSO.Level;
        }
        else if (ChangeUpgradeSO.ChangeAbilityType == ChangeAbilityType.Speed)
        {
            playerUpgrade.currentPlayerStats.CurrentSpeedLevel = _changeUpgradeSO.Level;
        }
        playerUpgrade.upgrades.Remove(_changeUpgradeSO);


        GameManager.Instance.SwitchState<PlayingState>();
    }
}
