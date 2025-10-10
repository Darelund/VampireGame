using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] private GameObject UpgradeUI;
    [SerializeField] private Transform UpgradeParent;

    [SerializeField] private GameObject addAbilityPrefab;
    [SerializeField] private GameObject changeAbilityPrefab;

    [SerializeField] private PlayerUpgrade playerUpgrade;
    private List<GameObject> upgradeUIs = new List<GameObject>();

    public override void EnterState()
    {
        UpgradeUI.SetActive(true);
        CreateUpgradeObjects();
    }
    public override void ExitState()
    {
        UpgradeUI.SetActive(false);
    }
    private void CreateUpgradeObjects()
    {
        //Need to remove the last UI upgrades
        for (int i = 0; i < upgradeUIs.Count; i++)
        {
            Destroy(upgradeUIs[i].gameObject);
            //Does this remove it from the list to? Doubt it, probably creates a missing reference.
            //But I guess it doesn't matter to much if I remove it here or after for loop
        }
        upgradeUIs.Clear();

        List<UpgradeSO> UpgradeListToUse = new();
        for (int i = 0; i < playerUpgrade.upgrades.Count; i++)
        {
            UpgradeListToUse.Add(playerUpgrade.upgrades[i]);
        }
        //playerUpgrade.upgrades.CopyTo(UpgradeListToUse);
        
        
        List<ChangeUpgradeSO> changeUpgradeList = new();
        for (int i = 0; i < playerUpgrade.upgrades.Count; i++)
        {
            if (playerUpgrade.upgrades[i] is ChangeUpgradeSO changeUpgradeSO)
            {
                changeUpgradeList.Add(changeUpgradeSO);
            }
        }


        //TODO: Quick solution to make Upgrades work based on the player has taken an upgrade or not. Change it later
        //Dash and Sprint has to be added separately right now
        //and we only work with ChangeUpgrades and not AddUpgrades right now
        switch (playerUpgrade.currentPlayerStats.CurrentHealthLevel)
        {
            case 0:
                changeUpgradeList.Remove(changeUpgradeList.Find(u => u.Level == 1 && u.ChangeAbilityType == ChangeAbilityType.Health));
                break;
            case 1:
                changeUpgradeList.Remove(changeUpgradeList.Find(u => u.Level == 2 && u.ChangeAbilityType == ChangeAbilityType.Health));
                break;
            case 2:
                changeUpgradeList.Remove(changeUpgradeList.Find(u => u.Level == 3 && u.ChangeAbilityType == ChangeAbilityType.Health));
                break;
            default:
                break;
        }
        switch (playerUpgrade.currentPlayerStats.CurrentSpeedLevel)
        {
            case 0:
                changeUpgradeList.Remove(changeUpgradeList.Find(u => u.Level == 1 && u.ChangeAbilityType == ChangeAbilityType.Speed));
                break;
            case 1:
                changeUpgradeList.Remove(changeUpgradeList.Find(u => u.Level == 2 && u.ChangeAbilityType == ChangeAbilityType.Speed));
                break;
            case 2:
                changeUpgradeList.Remove(changeUpgradeList.Find(u => u.Level == 3 && u.ChangeAbilityType == ChangeAbilityType.Speed));
                break;
            default:
                break;
        }

        for (int i = 0; i < changeUpgradeList.Count; i++)
        {
            if (changeUpgradeList[i].ChangeAbilityType == ChangeAbilityType.Sprint
                || changeUpgradeList[i].ChangeAbilityType == ChangeAbilityType.Dodge
                || changeUpgradeList[i].ChangeAbilityType == ChangeAbilityType.Dash) continue;
            UpgradeListToUse.Remove(UpgradeListToUse.Find(g => g == changeUpgradeList[i]));
        }


        var threeUpgradesToChooseFromList = new List<UpgradeSO>();
        threeUpgradesToChooseFromList = RandomlyDecideAnUpgrade(UpgradeListToUse);


        for (int i = 0; threeUpgradesToChooseFromList.Count > i; i++)
        {
            UpgradeSO upgradeSO = threeUpgradesToChooseFromList[i];
            GameObject upgradeGameObject = null;
            if (upgradeSO is AddUpgradeSO addUpgradeSO)
            {
               upgradeGameObject = Instantiate(addAbilityPrefab, UpgradeParent);
               upgradeGameObject.GetComponent<AddAbilityUpgrade>().NewAbilityPrefab = addUpgradeSO.Prefab;
                upgradeGameObject.GetComponent<AddAbilityUpgrade>().upgradeText.text = addUpgradeSO.Name;
            }
            else if (upgradeSO is ChangeUpgradeSO changeUpgradeSO)
            {
                upgradeGameObject = Instantiate(changeAbilityPrefab, UpgradeParent);
                upgradeGameObject.GetComponent<ChangeAbilityUpgrade>().upgradeText.text = changeUpgradeSO.ChangeAbilityType.ToString();
                upgradeGameObject.GetComponent<ChangeAbilityUpgrade>().ChangeUpgradeSO = changeUpgradeSO;
            }
            if (upgradeGameObject == null)
            {
                Debug.LogError("Upgrade object shouldn't be null");
                return;
            }
            upgradeGameObject.GetComponent<Upgrade>().upgradeImage.sprite = upgradeSO.Image;
            upgradeUIs.Add(upgradeGameObject);
        }
    }
    private List<UpgradeSO> RandomlyDecideAnUpgrade(List<UpgradeSO> upgradeList)
    {
        Debug.Log($"UpgradeList Count when trying to randomly choose upgrade: {upgradeList.Count}");
        List<UpgradeSO> threeUpgradeList = new();
        for(int i = 0; i < 10; i++)
        {
            var randomUpgrade = Random.Range(0, upgradeList.Count);
            if (!threeUpgradeList.Contains(upgradeList[randomUpgrade]))
            {
                threeUpgradeList.Add(upgradeList[randomUpgrade]);
            }
        }
        return threeUpgradeList;
    }
}
