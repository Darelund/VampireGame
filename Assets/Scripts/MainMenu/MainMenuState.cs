using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : State
{
    [SerializeField] private TMP_InputField inputField;
    public void StartGame()
    {
        if(inputField.text.Length > 0)
        {
            LoadDataManager.Instance.score.Name = inputField.text;
            SceneManager.LoadScene(1); // One being the first scene
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
