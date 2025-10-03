using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] private GameObject upgradePointObj;
    [SerializeField] private GameObject dyingPrefab;



    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }
    public override void Died()
    {
        var upgradePoint = Instantiate(upgradePointObj, transform.position, Quaternion.identity).GetComponent<UpgradePoint>();
        Instantiate(dyingPrefab, transform.position, Quaternion.identity);
        upgradePoint.InitializeUpgradePoint(33);
        GameManager.Instance.IncreaseEnemyKilledScoreByOne();
        GetComponent<ObjectToPool>().GiveBackToPool();
    }

}
