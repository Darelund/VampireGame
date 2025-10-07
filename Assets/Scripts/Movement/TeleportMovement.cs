using UnityEngine;

public class TeleportMovement : Moveable
{
    private float _teleportInterval;
    private float _teleportTimer;
    private float _spawnRadius;


    public TeleportMovement() : base()
    {
        _teleportInterval = RandomSpawnInterval();

        _spawnRadius = 10;
    }
    private int RandomSpawnInterval()
    {
        int lowestSpawnInterval = 5;
        int highestSpawnInterval = 12;

        return Random.Range(lowestSpawnInterval, highestSpawnInterval + 1);
    }

    protected override void Move(GameObject gameObject)
    {
        base.Move(gameObject);
        RandomTeleport(gameObject);
    }
    private void RandomTeleport(GameObject gameObject)
    {
        _teleportTimer += Time.deltaTime;
        if(_teleportTimer >= _teleportInterval)
        {
            _teleportInterval = RandomSpawnInterval();
            gameObject.transform.position = GetNewPosition(gameObject);
            _teleportTimer = 0;
        }
    }
    private Vector2 GetNewPosition(GameObject gameObject)
    {
        float newXPosition = Random.Range(gameObject.transform.position.x - _spawnRadius, gameObject.transform.position.x + _spawnRadius);
        float newYPosition = Random.Range(gameObject.transform.position.y - _spawnRadius, gameObject.transform.position.y + _spawnRadius);
        return new Vector2(newXPosition, newYPosition);
    }
}
