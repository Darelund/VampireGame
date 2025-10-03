using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void Died()
    {
        GameManager.Instance.SwitchState<GameOverState>();
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void PlayerHealth_OnValuesChanged(Dictionary<string, PlayerStat> stats)
    {
        maxHealth = stats["Health"].floatData;
        Debug.Log(stats["Health"].floatData);
        currentHealth = maxHealth;
        Debug.Log("Player health was modified");
        FireOffOnHealthChanged();
    }
}
