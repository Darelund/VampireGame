using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int currentExperiencePoints;
    public int currentLevel = 0;
    [SerializeField] public List<Level> levelUps;
    //[SerializeField] private GameObject AddAbilityGameObject;
    //[SerializeField] private GameObject ChangeAbilityGameObject;


    
    public Dictionary<string, (string, object)> abilityUpgrades;

    private void Awake()
    {
        CreateAbilitiesForLevels();
        CreateAbilityUpgrades();
    }
    private void CreateAbilitiesForLevels()
    {
        //levelUps = new List<Level>()
        //{
        //    new Level(0, new List<Upgrade>()), //Garbage zero level, maybe I give the player the choice so choose an upgrade at the start?
        //    new Level(50, new List<Upgrade>()
        //    {
        //        new AddAbilityUpgrade()
        //    }
        //    ),
        //    new Level(150, new List<Upgrade>()),
        //    new Level(300, new List<Upgrade>()),
        //    new Level(500, new List<Upgrade>())
        //};
    }
    private void CreateAbilityUpgrades()
    {
        abilityUpgrades = new Dictionary<string, (string Script, object value)>()
        {
            ["dash"] = ("PlayerMovement", true),
            ["dodge"] = ("PlayerMovement", true),
            ["health1"] = ("PlayerHealth", 150.0f),
            ["health2"] = ("PlayerHealth", 200),
            ["health3"] = ("PlayerHealth", 250),
            ["speed1"] = ("PlayerMovement", 10),
            ["speed2"] = ("PlayerMovement", 15),
            ["speed3"] = ("PlayerMovement", 20)

        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var upgradePoint = collision.GetComponent<UpgradePoint>();
        if (upgradePoint != null)
        {
            currentExperiencePoints += upgradePoint.GetPoints();
            VisualManager.Instance.SpawnText($"{upgradePoint.GetPoints()}+", transform.position, TextType.Normal, Color.darkGoldenRod);
            Destroy(upgradePoint.gameObject);
        }
        if(currentExperiencePoints >= levelUps[currentLevel + 1].ExperiencePoints)
        {
            currentLevel++;
            VisualManager.Instance.SpawnText($"LVL: {currentLevel} REACHED!", Vector2.zero, TextType.LvlUp, Color.darkGoldenRod);
            GameManager.Instance.SwitchState<UpgradeState>();
        }
    }
    
}
[System.Serializable]
public class Level
{
    public int ExperiencePoints;
    public List<UpgradeSO> Upgrades;

    public Level(int exp,  List<UpgradeSO> upgrades)
    {
        ExperiencePoints = exp;
        Upgrades = upgrades;
    }
}
