using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenuState : State
{
    [SerializeField] private TMP_InputField inputField;
    public void StartGame()
    {
        if(inputField.text.Length > 0)
        {
            LoadDataManager.Instance.gameData.scores.Add(new Score());
            var newestScore = LoadDataManager.Instance.gameData.scores[(LoadDataManager.Instance.gameData.scores.Count - 1)];
            newestScore.Name = inputField.text;
            LoadDataManager.Instance.SaveGameData();
            SceneManager.LoadScene(1); // One being the first scene
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
