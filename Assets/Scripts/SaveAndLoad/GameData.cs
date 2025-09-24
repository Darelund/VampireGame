using System.Collections.Generic;

using System;

[Serializable]
public class GameData
{
    public List<Score> scores = new List<Score>(); //JsonUtility can't work with stack, therefore I will use List, might use stack again when I re-learn how
    //to serialize json without JsonUtility
}
[Serializable]
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

    public override string ToString()
    {
        return $"{Hour}{Minute}{Second}";
    }
}
