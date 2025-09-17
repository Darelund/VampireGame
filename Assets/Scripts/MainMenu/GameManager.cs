using Unity.VisualScripting;
using UnityEngine;

public class GameManager : StateMachine
{
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
       // SwitchState<PlayingState>();
    }
    private void Update()
    {
        UpdateStateMachine();
    }
    //private static void Initialize()
    //{
    //    instance = 
    //}
}
