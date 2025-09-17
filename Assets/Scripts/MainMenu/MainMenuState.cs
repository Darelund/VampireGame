using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : State
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // One being the first scene
    }
    public void ExitGame()
    {
        Application.Quit();
    }



    //Det var en grej som jag inte riktigt förstod.
    /*
     * När vi använder state pattern för att skapa typ en fiende
     * måste vi då skapa en gå, springa, smyga, attackera, hoppa, etc... script och attacha alla dessa på enemy objektet?
     * Så vi har typ 10 scripts för det på fienden? Kan vi inte bara ha en EnemyMachine på spelaren och sen ha alla andra script använda EnemyMachine 
     * För att komma åt monobehaviour stuff och de ska inte vara attached till något. De är bara vanliga C# klasser
     * 
     */
}
