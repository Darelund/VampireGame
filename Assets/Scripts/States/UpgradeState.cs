using UnityEngine;

public class UpgradeState : State
{
    [SerializeField] private GameObject UpgradeUI;

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
        for (int i = 0; playerUpgrade.levelUps[playerUpgrade.currentLevel].Upgrades.Count > i; i++)
        {
            var upgradeSO = playerUpgrade.levelUps[playerUpgrade.currentLevel].Upgrades[i];
            GameObject upgradeGameObject = null;
            if (upgradeSO.AbilityType == AbilityType.AddAbility)
            {
               upgradeGameObject = Instantiate(addAbilityPrefab, UpgradeUI.transform.GetChild(1));
                upgradeGameObject.GetComponent<AddAbilityUpgrade>().NewAbilityPrefab = upgradeSO.Prefab;
            }
            else if (upgradeSO.AbilityType == AbilityType.ChangeAbility)
            {
                upgradeGameObject = Instantiate(changeAbilityPrefab, UpgradeUI.transform.GetChild(1));
                upgradeGameObject.GetComponent<ChangeAbilityUpgrade>()._upgrade = upgradeSO.Name;
            }
            if (upgradeGameObject == null)
            {
                Debug.LogError("Upgrade object shouldn't be null");
                return;
            }
            upgradeGameObject.GetComponent<Upgrade>().upgradeImage = upgradeSO.Image;
            upgradeGameObject.GetComponent<Upgrade>().upgradeText.text = upgradeSO.Name;
        }
    }
}
