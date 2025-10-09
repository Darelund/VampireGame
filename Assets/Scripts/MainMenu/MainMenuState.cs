using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuState : State
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Color errorColor;
    private const int MAX_NAME_LENGTH = 10;
    private bool canInteract = true;
    public void StartGame()
    {
        if (!canInteract) return;

        if(inputField.text.Length > MAX_NAME_LENGTH)
        {
            StartCoroutine(TemporarlyTextAndColorChanger("Max 10 characters allowed", 2));
            return;
        }
        if(inputField.text.Length > 0)
        {
            LoadDataManager.Instance.gameData.scores.Add(new Score());
            var newestScore = LoadDataManager.Instance.gameData.scores[(LoadDataManager.Instance.gameData.scores.Count - 1)];
            newestScore.Name = inputField.text;
            LoadDataManager.Instance.SaveGameData();
            SceneManager.LoadScene(1); // One being the first scene
        }
    }
    private IEnumerator TemporarlyTextAndColorChanger(string replacementText, float timeChanged)
    {
        string oldBtnText = inputField.text;
        Color oldColor = inputField.textComponent.color;
        canInteract = false;
        inputField.textComponent.color = errorColor;
        inputField.text = replacementText;

        yield return new WaitForSeconds(timeChanged);
        canInteract = true;
        inputField.text = oldBtnText;
        inputField.textComponent.color = oldColor;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
