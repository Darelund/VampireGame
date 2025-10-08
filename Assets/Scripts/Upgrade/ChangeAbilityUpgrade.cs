using System.Collections.Generic;
using UnityEngine;

public class ChangeAbilityUpgrade : Upgrade
{
    //[SerializeField] private PlayerStat stat;
    // [SerializeField] private string _upgrade;
    // public string GetUpgrade { get => _upgrade; set => _upgrade = value; }

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
        Debug.Log(_changeUpgradeSO.ChangeAbilityType.ToString());
        playerUpgrade.AbilityUpgrades[_changeUpgradeSO.ChangeAbilityType.ToString()] = _changeUpgradeSO.playerStat;
        playerUpgrade.FireChangeAbility();
        //playerUpgrade.AbilityUpgrades.
        GameManager.Instance.SwitchState<PlayingState>();
        Debug.Log("Changed ability");
        //TODO: Need to tell players components about this change. Movement might work, but health? Doesn't check until you take damage...
    }
}
