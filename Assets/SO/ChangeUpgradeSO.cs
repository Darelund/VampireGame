using UnityEngine;

[CreateAssetMenu(fileName = "ChangeUpgradeSO", menuName = "Scriptable Objects/ChangeUpgradeSO")]
public class ChangeUpgradeSO : UpgradeSO
{
    public PlayerStat playerStat;
    public ChangeAbilityType ChangeAbilityType;
}
public enum ChangeAbilityType
{
    Health,
    Speed,
    Sprint,
    Dodge,
    Dash
}
