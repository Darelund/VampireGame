using UnityEngine;

public abstract class Moveable : Attribute
{
     protected GameObject target;
     protected float speed = 5;
    public Moveable()
    {
        this.target = GameManager.Instance.Player; 
    }
    public override void UpdateAttribute(GameObject gameObject)
    {
        Move(gameObject);
    }
    protected virtual void Move(GameObject gameObject)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
