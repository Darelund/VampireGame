using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = currentHealth / maxHealth;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        slider.value = currentHealth / maxHealth;
    }
}
