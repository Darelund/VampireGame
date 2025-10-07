using UnityEngine;

public class OrbitMovement : Moveable
{
    private float _distance;

    public OrbitMovement() : base()
    {
        _distance = 5f;
    }
    protected override void Move(GameObject gameObject)
    {
        if (Vector2.Distance(gameObject.transform.position, target.transform.position) > _distance)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
            return;
        }
        float orbitScaler = 5;
        var orbitThingy = new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time), 0) * orbitScaler;
        gameObject.transform.position = orbitThingy + target.transform.position;
    }

    //var normalizedPos = (transform.position - target.transform.position).normalized;
    //var angleInRadians = Mathf.Atan2(normalizedPos.y, normalizedPos.x);
    //if(moveLeft)
    //{
    //    angleInRadians += Time.deltaTime;
    //}
    //else if(!moveLeft)
    //{
    //    angleInRadians -= Time.deltaTime;
    //}
    //var newNormalizedPosition = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
    //// var nonNormalizedPosition = new Vector2(Mathf.)

    // if((angleInRadians * Mathf.Rad2Deg) <= 0 && (angleInRadians * Mathf.Rad2Deg) >= 90)
    // {
    //     Mathf.Sin(angleInRadians);
    // }
    // else if ((angleInRadians * Mathf.Rad2Deg) <= 91 && (angleInRadians * Mathf.Rad2Deg) >= 180)
    // {
    //     Mathf.Sin(angleInRadians);
    // }
    // else if ((angleInRadians * Mathf.Rad2Deg) <= 181 && (angleInRadians * Mathf.Rad2Deg) >= 270)
    // {
    //     Mathf.Sin(angleInRadians);
    // }
    // else if ((angleInRadians * Mathf.Rad2Deg) <= 271 && (angleInRadians * Mathf.Rad2Deg) >= 360)
    // {
    //     Mathf.Sin(angleInRadians);
    // }
    //Random.unit


    //TODO: ADD THE FUCKING CODE
    // Debug.Log("Basically go around in circles");

    //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
}
