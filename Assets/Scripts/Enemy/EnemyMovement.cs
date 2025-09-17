using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] private float speed;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }
    void Update()
    {
        Move();
        LookAtPlayer();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void LookAtPlayer()
    {
        var playerDir = (target.transform.position - transform.position).normalized;
        var angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
