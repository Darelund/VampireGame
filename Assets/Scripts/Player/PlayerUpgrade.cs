using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int currentExperiencePoints;
    public int nextLevel = 0;
    [SerializeField] private List<Level> levelUps;

    [SerializeField] public TMP_Text lvlUpText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var upgradePoint = collision.GetComponent<UpgradePoint>();
        if (upgradePoint != null)
        {
            currentExperiencePoints += upgradePoint.points;
            Destroy(upgradePoint.gameObject);
        }
        if(currentExperiencePoints >= levelUps[nextLevel].ExperiencePoints)
        {
            nextLevel++;
            lvlUpText.text = $"LVL: {nextLevel} REACHED!";
            lvlUpText.gameObject.SetActive(true);
        }
    }
}
[System.Serializable]
public class Level
{
    public int ExperiencePoints;
    public List<Upgrade> Upgrades;

}
[System.Serializable]
public class Upgrade
{
    public string Name;
}
