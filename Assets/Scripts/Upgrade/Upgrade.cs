using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] protected UpgradeSO upgradeSO;
     //public UpgradeSO GetUpgradeSO
     protected PlayerController playerController;

    [SerializeField] public Image upgradeImage;
    [SerializeField] public TMP_Text upgradeText;


   public virtual void Awake()
    {
        playerController = GameObject.FindAnyObjectByType<PlayerController>();
    }
    public abstract void ActivateAbility();
}
