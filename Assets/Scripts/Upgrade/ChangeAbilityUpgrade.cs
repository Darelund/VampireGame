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
        GameManager.Instance.SwitchState<PlayingState>();
    }
}
