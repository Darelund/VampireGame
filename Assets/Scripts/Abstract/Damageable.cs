using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;
    [SerializeField] public event EventHandler<HealthChangedEventArgs> OnHealthChanged;

    public bool IsAlive => currentHealth > 0;

    protected virtual void Awake()
    {
        Init();
    }
    protected virtual void Start()
    {
        FireOffOnHealthChanged();
    }
    public virtual void Init()
    {
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        FireOffOnHealthChanged(dmg);
        SoundManager.Instance.PlaySound("Player", "Hurt");
        if (!IsAlive) Died();
    }
    public virtual void Died()
    {
        //Died :(
        //Destroy(transform.gameObject); 
    }
    public virtual void RecieveHealth(float hp)
    {
        currentHealth += hp; //++
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public void FireOffOnHealthChanged(float damage = 0)
    {
        OnHealthChanged?.Invoke(this, new HealthChangedEventArgs(currentHealth, maxHealth, damage));
    }
    public class HealthChangedEventArgs : EventArgs
    {
        public float CurrentHealth;
        public float MaxHealth;
        public float Damage;
        public HealthChangedEventArgs(float currentHealth, float maxHealth, float damage)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            Damage = damage;
        }
    }
}

