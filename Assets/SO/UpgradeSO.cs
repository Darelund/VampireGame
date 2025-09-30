using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string Description; //Maybe add a description when you hover over the upgrade
    public Sprite Image;


    //public AbilityType AbilityType;
    public GameObject Prefab;
}
