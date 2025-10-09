using UnityEngine;

public class OrbitMovement : Moveable
{
    private float _distance;
    private float _orbitSpeed;

    public OrbitMovement() : base()
    {
        _distance = 8f;
        _orbitSpeed = 75f;
    }
    protected override void Move(GameObject gameObject)
    {
        if (Vector2.Distance(gameObject.transform.position, target.transform.position) > _distance)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);
            return;
        }
      //  float orbitScaler = 5;
        gameObject.transform.RotateAround(target.transform.position, Vector3.forward, _orbitSpeed * Time.deltaTime);


        //var orbitPosition = new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time), 0) * orbitScaler;
        //gameObject.transform.position = orbitPosition + target.transform.position;
    }

}
