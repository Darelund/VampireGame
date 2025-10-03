using UnityEngine;

public abstract class Moveable : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] private float speed;


    protected void Start()
    {
        //Now this one is broke because I create enemies at the beginning at the scene instead of later
        //I couldn't run this on start before because the Move/Update below runs before this ones Start
        //But now I moved the creation to the beginning so it should be fine doing this in Start again
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
