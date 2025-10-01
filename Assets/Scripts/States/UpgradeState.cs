using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] private GameObject UpgradeUI;
    [SerializeField] private Transform UpgradeParent;

    [SerializeField] private GameObject addAbilityPrefab;
    [SerializeField] private GameObject changeAbilityPrefab;

    [SerializeField] private PlayerUpgrade playerUpgrade;

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
        for (int i = 0; playerUpgrade.levelUps[playerUpgrade.GetCurrentLevel].Upgrades.Count > i; i++)
        {
            UpgradeSO upgradeSO = playerUpgrade.levelUps[playerUpgrade.GetCurrentLevel].Upgrades[i];
            GameObject upgradeGameObject = null;
            if (upgradeSO is AddUpgradeSO addUpgradeSO)
            {
               upgradeGameObject = Instantiate(addAbilityPrefab, UpgradeParent);
               upgradeGameObject.GetComponent<AddAbilityUpgrade>().NewAbilityPrefab = upgradeSO.Prefab;
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
        }
    }
}
