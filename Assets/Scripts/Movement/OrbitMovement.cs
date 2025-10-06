using UnityEngine;

public class OrbitMovement : Moveable
{
    [SerializeField] private float distance = 5f;
    protected override void Move()
    {
        if(Vector2.Distance(transform.position, target.transform.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            //TODO: ADD THE FUCKING CODE
            Debug.Log("Basically go around in circles");
        }
    }
}
