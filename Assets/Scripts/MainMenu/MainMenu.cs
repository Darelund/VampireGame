using UnityEngine;


public class MainMenu : MonoBehaviour
{
    //[SerializeField] private GameState currentGameState;

    ////public GameObject MainMenuUI;
    ////public GameObject OptionsUI;
    ////public GameObject LevelSelectUI;
    ////public GameObject GameOverUI;
    //public GameObject[] Menus;



    //private void Update()
    //{
    //   switch(currentGameState)
    //    {
    //        case GameState.MainMenu:
    //            break;
    //        case GameState.LevelSelect:
    //            break;
    //        case GameState.Option:
    //            break;
    //        case GameState.GameOver:
    //            break;
    //    }
    //}
    //public void ChangeState(int NewState)
    //{
    //    ChangeState((GameState)NewState);
    //}

    //public void ChangeState(GameState newGameState)
    //{
    //    if(currentGameState == newGameState) return;
    //    currentGameState = newGameState;
    //    for(int i = 0; i < Menus.Length; i++)
    //    {
    //        Menus[i].SetActive(newGameState == currentGameState);
    //    }
    //}

    //public void StartGame()
    //{

    //}
    //public void ExitGame()
    //{
    //    Application.Quit();
    //}
}
//public class MainMenuBrain : MonoBehaviour
//{
//    private MainMenuState mainMenuState;
//    private OptionState optionState;
//    private LevelSelectState levelSelectState;
//    private GameOverState gameOverState;

//    private MainMenuStates currentMainMenuState;

//    private void Awake()
//    {
//        mainMenuState = new MainMenuState(this);
//        optionState = new OptionState(this);
//        levelSelectState = new LevelSelectState(this);
//        gameOverState = new GameOverState(this);

//        currentMainMenuState = mainMenuState;
//        currentMainMenuState.OnStart();
//    }

//    private void Update()
//    {
//        currentMainMenuState.Update();
//    }
//    public void SwitchState(MainMenuState newState)
//    {
//        if(currentMainMenuState == newState) return;
//        currentMainMenuState.OnExit();
//        currentMainMenuState = newState;
//        currentMainMenuState.OnStart();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        currentMainMenuState.OnCollisionEnter(collision);
//    }
//}
//public abstract class MainMenuStates
//{
//    protected MainMenuBrain MainMenuBrain;
//    public MainMenuStates(MainMenuBrain mainMenuBrain)
//    {
//        MainMenuBrain = mainMenuBrain;
//    }
//    public abstract void OnStart();
//    public abstract void Update();
//    public abstract void OnExit();

//    public abstract void OnCollisionEnter(Collision collision);
    
//}
//public class MainMenuState : MainMenuStates
//{
//    public MainMenuState(MainMenuBrain mainMenuBrain) : base(mainMenuBrain)
//    {
//    }
//    public override void OnCollisionEnter(Collision collision)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnExit()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnStart()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void Update()
//    {
//        throw new System.NotImplementedException();
//    }
//}
//public class OptionState : MainMenuStates
//{
//    public OptionState(MainMenuBrain mainMenuBrain) : base(mainMenuBrain)
//    {
//    }
//    public override void OnCollisionEnter(Collision collision)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnExit()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnStart()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void Update()
//    {
//        throw new System.NotImplementedException();
//    }
//}
//public class LevelSelectState : MainMenuStates
//{
//    public LevelSelectState(MainMenuBrain mainMenuBrain) : base(mainMenuBrain)
//    {
//    }
//    public override void OnCollisionEnter(Collision collision)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnExit()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnStart()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void Update()
//    {
//        throw new System.NotImplementedException();
//    }
//}
//public class GameOverState : MainMenuStates
//{
//    public GameOverState(MainMenuBrain mainMenuBrain) : base(mainMenuBrain)
//    {
//    }
//    public override void OnCollisionEnter(Collision collision)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnExit()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void OnStart()
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void Update()
//    {
//        throw new System.NotImplementedException();
//    }
//}
