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



    //Det var en grej som jag inte riktigt f�rstod.
    /*
     * N�r vi anv�nder state pattern f�r att skapa typ en fiende
     * m�ste vi d� skapa en g�, springa, smyga, attackera, hoppa, etc... script och attacha alla dessa p� enemy objektet?
     * S� vi har typ 10 scripts f�r det p� fienden? Kan vi inte bara ha en EnemyMachine p� spelaren och sen ha alla andra script anv�nda EnemyMachine 
     * F�r att komma �t monobehaviour stuff och de ska inte vara attached till n�got. De �r bara vanliga C# klasser
     * 
     */
}
