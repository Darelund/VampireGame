using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradeSO upgradeSO;
     protected PlayerController playerController;

    [SerializeField] public Image upgradeImage;
    [SerializeField] public TMP_Text upgradeText;


   public virtual void Awake()
    {
        playerController = GameObject.FindAnyObjectByType<PlayerController>();

        //upgradeImage = upgradeSO.Image;
        //upgradeText.text = upgradeSO.name;

    }
    public virtual void ActivateAbility()
    {
        //if(upgradeSO.AbilityType == AbilityType.ChangeAbility)
        //{
        //    //Change something on x script in PlayerController
        //    //We need to know what script to access
        //    //and what value to change and to what

        //    if (upgradeSO.NameOfScriptToAccess == "PlayerShooter")
        //    {

        //    }
        //    if (upgradeSO.NameOfScriptToAccess == "PlayerHealth")
        //    {

        //    }
        //    if (upgradeSO.NameOfScriptToAccess == "PlayerMovement")
        //    {

        //    }
        //}
        //else if (upgradeSO.AbilityType == AbilityType.AddAbility)
        //{
        //    //Add object to PlayerController
        //    //We need a prefab
        // //  Instantiate(upgradeSO.NewAbilityPrefab, playerController.transform);
        //}
    }
}
