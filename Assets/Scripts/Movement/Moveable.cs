using UnityEngine;

public abstract class Moveable : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] private float speed;


    protected void Awake()
    {
        target = GameManager.Instance.Player;
        Debug.Log(target == null);
    }

    public void UpdateMovement()
    {
        Move();
    }
    protected virtual void Move()
    {
        if(target == null)
        {
            Debug.Log("AM I THE NULL ONE?");
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
