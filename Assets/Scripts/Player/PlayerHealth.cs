using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    //TODO: Separate logic and visuals. Make a "OnHealthChanged" event that triggers when damaged. Make a Healthbar component for enemies, players, etc... 
    [SerializeField] private HealthBar healthBar;
    protected override void Awake()
    {
        //maxHealth = 
        base.Awake();
    }
    private void Start()
    {
        UpdateHealthBar();
    }
    public override void SetmaxHealth(float maxHealth)
    {
        base.SetmaxHealth(maxHealth);
        UpdateHealthBar();
    }
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        UpdateHealthBar();
    }
    public override void Died()
    {
        //Died :(
        GameManager.Instance.SwitchState<GameOverState>();
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void PlayerHealth_OnValuesChanged(Dictionary<string, PlayerStat> stats)
    {
        maxHealth = stats["Health"].floatData;
        Debug.Log(stats["Health"].floatData);
        currentHealth = maxHealth;
        Debug.Log("Player health was modified");
        UpdateHealthBar();
    }
    private void UpdateHealthBar() => healthBar.UpdateHealthBar(currentHealth, maxHealth);
}
