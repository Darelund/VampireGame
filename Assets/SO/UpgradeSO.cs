using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public int Level; //What level the player has to be to be able to see this as an upgrade
    public string Description; //Maybe add a description when you hover over the upgrade
    public Sprite Image;


    //public AbilityType AbilityType;
    //
}
