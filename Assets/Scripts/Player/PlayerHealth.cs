using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
    public override void SetmaxHealth(float maxHealth)
    {
        base.SetmaxHealth(maxHealth);
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
    public override void Died()
    {
        //Died :(
        GameManager.Instance.SwitchState<GameOverState>();
        Destroy(transform.gameObject);
    }
}
