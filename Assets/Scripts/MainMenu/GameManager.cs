using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : StateMachine, ISaveable
{
    // [SerializeField] private PlayerMovement
    private int _enemiesKilled;
    public int GetEnemiesKilled
    {
        get => _enemiesKilled;
    }

    public void IncreaseEnemyKilledScoreByOne()
    {
        _enemiesKilled++;
    }



    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null) Destroy(gameObject);
        instance = this;
    }
    private void Start()
    {
        SwitchState<PlayingState>();
    }
    private void Update()
    {
        UpdateStateMachine();

        
    }

    public void Save(Score score)
    {
        score.EnemiesKilled = _enemiesKilled;

        TimeSpan time = TimeSpan.FromSeconds(Time.time);
        score.Time = new PlayedTime(time.Hours, time.Minutes, time.Seconds);
    }
}
