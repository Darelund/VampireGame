using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float damage;
    [SerializeField] private GameObject destroyedParticle;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Init(Vector2 dir, float speed)
    {
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        RightRotation(dir);
    }
    private void RightRotation(Vector2 dir)
    {
        var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageableObject = collision.collider.GetComponent<Damageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
            Debug.Log($"Did dmg: {damage}");
            Debug.Log($"target has: {damageableObject.GetCurrentHealth} hp left");
        }
        DestroyItself();
    }
    private void DestroyItself()
    {
        Destroy(transform.gameObject);
        Instantiate(destroyedParticle, transform.position, Quaternion.identity);
    }
}
