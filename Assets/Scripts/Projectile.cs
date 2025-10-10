using UnityEngine;


public class Projectile : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private float damage;
    [SerializeField] private GameObject destroyedParticle;

    [SerializeField] private Vector2 dir;
    [SerializeField] private float speed;

    [SerializeField] private GameObject visuals;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Init(Vector2 dir, float speed)
    {
        this.dir = dir;
        this.speed = speed;

        //  rb.AddForce(dir * speed, ForceMode2D.Impulse);
        GetFacingDirection(dir);
    }
    private void GetFacingDirection(Vector2 dir)
    {
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void UpdateProjectile()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 6 && gameObject.layer == 6) return; //We don't want the player to shoot themselves
        var damageableObject = collision.collider.GetComponent<Damageable>();
        if (damageableObject != null && damageableObject.GetComponent<Projectile>() == null)
        {
            //Todo: Come up with different projectiles, with different damage
            int dmg = Random.Range(5, 10);
            damageableObject.TakeDamage(dmg);
        }
        DestroyItself();
    }
    //TODO:Probably want to integrate this into an object pool
    private void DestroyItself()
    {
        currentHealth = 0;
        visuals.SetActive(false);
        Instantiate(destroyedParticle, transform.position, Quaternion.identity);
        SoundManager.Instance.PlayRandomSoundFromSoundData("Projectile");
    }
}
