using System;
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

    public event Action<Dictionary<string, PlayerStat>> OnChangeAbility;


    private Dictionary<string, PlayerStat> abilityUpgrades;
    public Dictionary<string, PlayerStat> AbilityUpgrades
    {
        get { return abilityUpgrades; }
        set 
        { 
            abilityUpgrades = value; 
            OnChangeAbility?.Invoke(abilityUpgrades);
        }
    }
    public void FireChangeAbility()
    {
        OnChangeAbility?.Invoke(abilityUpgrades);
    }

    private void Awake()
    {
        CreateAbilityUpgrades();

        UpdateUpgradeBar(currentExperiencePoints, levelUps[currentLevel + 1].ExperiencePoints);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentExperiencePoints += 10;
            if (CanReachNextLevel())
            {
                ReachedNextLevel();
            }
            int nextLevelIndex = currentLevel + 1;
            UpdateUpgradeBar(currentExperiencePoints, levelUps[nextLevelIndex].ExperiencePoints);
        }
    }
    private void CreateAbilityUpgrades()
    {
        abilityUpgrades = new Dictionary<string, PlayerStat>()
        {
            ["Dash"]    =  new(boolData: false),
            ["Dodge"]   =  new(boolData: false),
            ["Sprint"]  =  new(boolData: false),
            ["Health"]  =  new(floatData: 100),
            ["Speed"]   =  new(floatData: 5)
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIfUpgrade(collision, out UpgradePoint upgradePoint))
        {
            AddExperiencePoints(upgradePoint);
            if(CanReachNextLevel())
            {
                ReachedNextLevel();
            }
            int nextLevelIndex = currentLevel + 1;
            UpdateUpgradeBar(currentExperiencePoints, levelUps[nextLevelIndex].ExperiencePoints);
        }
    }
    private bool CheckIfUpgrade(Collider2D collision, out UpgradePoint upgradePoint)
    {
        upgradePoint = collision.GetComponent<UpgradePoint>();
        return (upgradePoint == null);
    }
    private void AddExperiencePoints(UpgradePoint upgradePoint)
    {
        if (upgradePoint != null)
        {
            currentExperiencePoints += upgradePoint.GetPoints();
            VisualManager.Instance.SpawnText($"{upgradePoint.GetPoints()}+", transform.position, TextType.Normal, Color.darkGoldenRod);
            Destroy(upgradePoint.gameObject);
        }
    }

    private bool CanReachNextLevel()
    {
        int nextLevelIndex = currentLevel + 1;
        return (currentExperiencePoints >= levelUps[nextLevelIndex].ExperiencePoints);
    }
    private void ReachedNextLevel()
    {
        currentLevel++;
        totalExperiencePoints += currentExperiencePoints;
        currentExperiencePoints = 0; //We want the slider to go back to zero. I am not sure if we should reset it to 0. We probably want it to keep its experience points
                                     //VisualManager.Instance.SpawnText($"LVL: {currentLevel} REACHED!", Vector2.zero, TextType.LvlUp, Color.darkGoldenRod);
        GameManager.Instance.SwitchState<UpgradeState>();
        SoundManager.Instance.PlaySound("LevelUp", "FantasyLevelUpSound");
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
[System.Serializable]
public class PlayerStat
{
    public string stringData;
    public float floatData;
    public bool boolData;

    public PlayerStat(string stringData = "", float floatData = 0, bool boolData = false)
    {
        this.stringData = stringData;
        this.floatData = floatData;
        this.boolData = boolData;
    }

   // public PlayerStat() { }
}
