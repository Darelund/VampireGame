using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : State
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject namePanel;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Color errorColor;
    private const int MAX_NAME_LENGTH = 10;
    private bool canInteract = true;

    public override void EnterState()
    {
        base.EnterState();
        GameOverUI.SetActive(true);
    }
    public override void UpdateState()
    {
        base.UpdateState();
       
    }
    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

    }
    public void SaveScore()
    {
        if (!canInteract) return;

        if (inputField.text.Length > MAX_NAME_LENGTH)
        {
            StartCoroutine(TemporarlyTextAndColorChanger("Max 10 characters allowed", 2));
            return;
        }
        if (inputField.text.Length > 0)
        {
            LoadDataManager.Instance.gameData.scores.Add(new Score());
            var newestScore = LoadDataManager.Instance.gameData.scores[(LoadDataManager.Instance.gameData.scores.Count - 1)];
            newestScore.Name = inputField.text;
            LoadDataManager.Instance.SaveGameData();
            namePanel.SetActive(false);
            menuPanel.SetActive(true);
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
    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0); //0 Is the MainMenu, if I add an intro I might have to change this
    }
    public void ExitToDesktop()
    {
        Application.Quit();
    }

   
}
