

using System;

[Serializable]
public class Score
{
    public int Rank;
    public string Name;
    public int ExperiencePoints;
    public int Waves;
    public int Level;
    public int EnemiesKilled;
    //public PlayedTime Time;

    public Score(int rank, string name, int exp, int waves, int level, int enemiesKilled, PlayedTime time)
    {
        Rank = rank;
        Name = name;
        ExperiencePoints = exp;
        Waves = waves;
        Level = level;
        EnemiesKilled = enemiesKilled;
       // Time = time;
    }
    public Score() { }
    public Score GetScore() => this;

    public override string ToString()
    {
        return $"{Rank} {Name} {ExperiencePoints} {Waves} {Level} {EnemiesKilled} ";
    }
}
