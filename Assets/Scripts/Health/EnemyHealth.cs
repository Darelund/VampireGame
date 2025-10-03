using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHealth : Damageable
{
    [SerializeField] private GameObject UpgradePointObj;


    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }
    public override void Died()
    {
        var upgradePoint = Instantiate(UpgradePointObj, transform.position, Quaternion.identity).GetComponent<UpgradePoint>();
        upgradePoint.InitializeUpgradePoint(33);
        GameManager.Instance.IncreaseEnemyKilledScoreByOne();
    }

}
