using System;
using UnityEngine;


//[Serializable] You don't need to
public class Score
{
    public string Name;
    public int ExperiencePoints;
    public int Waves;
    public int Level;
    public int EnemiesKilled;
    public PlayedTime Time;

    public Score(string name, int exp, int waves, int level, int enemiesKilled, PlayedTime time)
    {
        this.Name = name;
        this.ExperiencePoints = exp;
        this.Waves = waves;
        this.Level = level;
        EnemiesKilled = enemiesKilled;
        Time = time;
    }
    public Score() { }
    public Score GetScore() => this;//Or should I return a new object?
}
