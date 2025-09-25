using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : StateMachine, ISaveable
{
    // [SerializeField] private PlayerMovement
    private int _enemiesKilled;
    //public string Name;

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
    private void LateUpdate()
    {
        LateUpdateStateMachine();
    }

    public void Save(GameData score)
    {
        var newestScore = score.scores[(score.scores.Count - 1)];
        newestScore.EnemiesKilled = _enemiesKilled;
        //score.Name = Name;
        TimeSpan time = TimeSpan.FromSeconds(Time.time);
        //newestScore.Time = new PlayedTime(time.Hours, time.Minutes, time.Seconds);
    }
}
