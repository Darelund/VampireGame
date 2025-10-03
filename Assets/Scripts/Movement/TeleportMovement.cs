using UnityEngine;

public class TeleportMovement : Moveable
{
    [SerializeField] private float teleportInterval = 5;
    [SerializeField] private float teleportTimer;
    [SerializeField] private float spawnRadius;


    protected override void Move()
    {
        base.Move();
        RandomTeleport();
    }
    private void RandomTeleport()
    {
        teleportTimer += Time.deltaTime;
        if(teleportTimer >= teleportInterval)
        {
            //Spawn
            transform.position = GetNewPosition();
            teleportTimer = 0;
        }
    }
    private Vector2 GetNewPosition()
    {
        float newXPosition = Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius);
        float newYPosition = Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius);
        return new Vector2(newXPosition, newYPosition);
    }
}
