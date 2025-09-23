using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private int currentExperiencePoints;
    private int totalExperiencePoints;
    [SerializeField] private int currentLevel = 0;
    [SerializeField] public List<Level> levelUps;

    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text currentLevelText;

    private void UpdateUpgradeBar(float curr, float max)
    {
        slider.value = curr / max;
        currentLevelText.text = $"LVL:{currentLevel}";
    }

    public int GetTotalExperiencePoints => totalExperiencePoints;
    public int GetCurrentLevel => currentLevel;


    public Dictionary<string, (string, object)> abilityUpgrades;

    private void Awake()
    {
        CreateAbilityUpgrades();

        UpdateUpgradeBar(currentExperiencePoints, levelUps[currentLevel + 1].ExperiencePoints);
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
            totalExperiencePoints += currentExperiencePoints;
            currentExperiencePoints = 0; //We want the slider to go back to zero. I am not sure if we should reset it to 0. We probably want it to keep its experience points
            VisualManager.Instance.SpawnText($"LVL: {currentLevel} REACHED!", Vector2.zero, TextType.LvlUp, Color.darkGoldenRod);
            GameManager.Instance.SwitchState<UpgradeState>();
        }
        UpdateUpgradeBar(currentExperiencePoints, levelUps[currentLevel + 1].ExperiencePoints);
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
