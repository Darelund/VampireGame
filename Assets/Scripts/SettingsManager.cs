using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private GameSettings _gameSettings;
    public GameSettings GameSettings => _gameSettings;
    private IFileSaver<GameSettings> _fileSaver;

    private List<ISaveable<GameSettings>> saveableElements = new List<ISaveable<GameSettings>>();

    private void Awake()
    {
        _fileSaver = new JsonSaver<GameSettings>();
        _fileSaver.FileName = "GameSettings.json";
        _gameSettings = _fileSaver.Load();
        //Debug.Log(_gameSettings.ToString());    
        Debug.Log("I run");

        Application.quitting += Application_quitting;
        saveableElements = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None).OfType<ISaveable<GameSettings>>().ToList();
        Debug.Log(saveableElements.Count);

        LoadSavedSettings();
    }
    private void Application_quitting()
    {
        SaveGameSettings();
    }
    private void LoadSavedSettings()
    {
        //If no settings was found then we will use the default settings
        if(_gameSettings == null)
        {
            _gameSettings = new GameSettings();
        }
        foreach (var element in saveableElements)
        {
            element.Load(GameSettings);
        }
    }
    private void SaveGameSettings()
    {
        foreach (var element in saveableElements)
        {
            element.Save(GameSettings);
        }

        _fileSaver.Save(GameSettings);
    }
}
