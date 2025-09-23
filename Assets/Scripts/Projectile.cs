using UnityEngine;

public enum ProjectileOwner
{
    Player,
    NonPlayer
}
public class Projectile : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private float damage;
    [SerializeField] private GameObject destroyedParticle;

    [SerializeField] private Vector2 dir;
    [SerializeField] private float speed;

    [SerializeField] private GameObject visuals;

    public ProjectileOwner owner;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Init(Vector2 dir, float speed)
    {
        this.dir = dir;
        this.speed = speed;

        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        RightRotation(dir);
    }
    public void UpdateProjectile()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }
    private void RightRotation(Vector2 dir)
    {
        var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageableObject = collision.collider.GetComponent<Damageable>();
        if (damageableObject != null && damageableObject.GetComponent<Projectile>() == null)
        {
            //Todo: Come up with different projectiles, with different damage
            int dmg = Random.Range(15, 30);
            damageableObject.TakeDamage(dmg);
        }
        DestroyItself();
    }
    private void DestroyItself()
    {
        currentHealth = 0;
        visuals.SetActive(false);
        Instantiate(destroyedParticle, transform.position, Quaternion.identity);
    }
}
