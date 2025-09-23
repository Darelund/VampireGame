using UnityEngine;

public class GameData : MonoBehaviour
{
    
}
public class PlayedTime
{
    public readonly float Hour;
    public readonly float Minute;
    public readonly float Second;

    public PlayedTime(float hour, float minute, float second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }
    public PlayedTime GetPlayedTime() => new PlayedTime(Hour, Minute, Second);
}
