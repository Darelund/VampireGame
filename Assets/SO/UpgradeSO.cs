using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string Name;
    public string Description; //Maybe add a description when you hover over the upgrade
    public Image Image;


    public AbilityType AbilityType;
    public GameObject Prefab;
}
public enum AbilityType
{
    ChangeAbility, //Change a value on an existing class the player has
    AddAbility // add a new GameObject to the player
}