using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour //TODO: Maybe make this code work for enemies in the future, at the moment enemies don't need a healthbar
{
    [SerializeField] private Slider slider;
    [SerializeField] private Damageable damageable;


    private void Awake()
    {
        damageable.OnHealthChanged += HealthBar_OnHealthChanged;
    }

    private void HealthBar_OnHealthChanged(object sender, Damageable.HealthChangedEventArgs e)
    {
        UpdateHealthBar(e.CurrentHealth, e.MaxHealth);
    }

    

    public void UpdateHealthBar(float curr, float max)
    {
        slider.value = curr / max;
    }
    private void OnDestroy()
    {
        damageable.OnHealthChanged += HealthBar_OnHealthChanged;
    }
}
