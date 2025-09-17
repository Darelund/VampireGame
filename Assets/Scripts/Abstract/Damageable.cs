using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;

    public float GetCurrentHealth => currentHealth;

    public bool IsAlive => currentHealth > 0;

    protected void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (!IsAlive) Died();
    }
    public virtual void Died()
    {
        //Died :(
        Destroy(transform.gameObject);
    }
    public virtual void RecieveHealth(float hp)
    {
        currentHealth += hp; //++
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
