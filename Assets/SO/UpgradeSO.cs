using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string Name;
    public string Description; //Maybe add a description when you hover over the upgrade
    public Image Image;

    //public object ValueToUpgrade; //I don't know what to call this. This should be the int, string, float, object, class to change/add to the player

    public AbilityType AbilityType;
    public GameObject Prefab;
}
public enum AbilityType
{
    ChangeAbility, //Change a value on an existing class the player has
    AddAbility // add a new GameObject to the player
}