using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int currentExperiencePoints;
    public int nextLevel = 0;
    [SerializeField] private List<Level> levelUps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var upgradePoint = collision.GetComponent<UpgradePoint>();
        if (upgradePoint != null)
        {
            currentExperiencePoints += upgradePoint.GetPoints();
            VisualManager.Instance.SpawnText($"{upgradePoint.GetPoints()}+", transform.position, TextType.Normal);
            Destroy(upgradePoint.gameObject);
        }
        if(currentExperiencePoints >= levelUps[nextLevel + 1].ExperiencePoints)
        {
            nextLevel++;
            VisualManager.Instance.SpawnText($"LVL: {nextLevel} REACHED!", Vector2.zero, TextType.LvlUp);
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
