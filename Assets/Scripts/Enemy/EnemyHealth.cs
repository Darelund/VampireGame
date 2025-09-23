using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] private GameObject innerObj;
    [SerializeField] private List<HealthColor> healthColors;
    [SerializeField] private GameObject UpgradePointObj;
    [SerializeField] private GameObject visuals;


    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        VisualManager.Instance.SpawnText($"{dmg}+", transform.position, TextType.Normal, Color.darkRed);
        HealthColor healthColor;
        string healthName = "";
        if (currentHealth >= maxHealth/2)
        {
            healthName = "High";
        }
        else if (currentHealth < maxHealth / 2 && currentHealth > maxHealth/4)
        {
            healthName = "Medium";
        }
        else
        {
            healthName = "Low";
        }
        //Debug.Log(healthName);
        //healthColor = healthColors.Where(hc => hc.Name == healthName) as HealthColor;
        healthColor = healthColors.Find(hc => hc.Name == healthName);
        //Debug.Log(healthColor == null);
        //Debug.Log(innerObj.GetComponent<SpriteRenderer>() == null);
        innerObj.GetComponent<SpriteRenderer>().color = healthColor.Color;
    }
    public override void Died()
    {
        var upgradePoint = Instantiate(UpgradePointObj, transform.position, Quaternion.identity).GetComponent<UpgradePoint>();
        upgradePoint.InitializeUpgradePoint(33);
        visuals.SetActive(false);
        GameManager.Instance.IncreaseEnemyKilledScoreByOne();
    }

}
[System.Serializable]
public class HealthColor
{
    public string Name;
    public Color32 Color;
}
