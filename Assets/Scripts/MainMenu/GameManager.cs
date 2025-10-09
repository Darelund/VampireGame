using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : StateMachine, ISaveable<GameData>
{
    [SerializeField] private GameObject player;
    public GameObject Player => player; 




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
        player = GameObject.Find("Player");
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
