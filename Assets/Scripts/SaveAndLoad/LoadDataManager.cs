using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LoadDataManager : MonoBehaviour
{
    //Create Score
    //We need references from x, y and z
    //Use Json, and File class to write to a file

    //And then get the score in the main menu

    private static LoadDataManager instance;
    public static LoadDataManager Instance
    {
        get
        {
            return instance;
        }
    }
    public GameData gameData;

    private IFileSaver<GameData> _fileSaver;
    private List<ISaveable<GameData>> saveableElements = new List<ISaveable<GameData>>();

    private void Awake()
    {
        if (instance != null) 
            Destroy(gameObject);

        instance = this;
        _fileSaver = new JsonSaver<GameData>();
        saveableElements = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).OfType<ISaveable<GameData>>().ToList();
        LoadGameData();
        Application.quitting += Application_quitting;
    }

    private void Application_quitting()
    {
        SaveGameData();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.C))
        //{
        //    SaveGameData();
        //}
    }
    public void SaveGameData()
    {
        //gameData.scores.Push(new Score());

        foreach (var element in saveableElements)
        {
            element.Save(gameData);
        }

        _fileSaver.Save(gameData);
    }
    public void LoadGameData()
    {
        gameData = _fileSaver.Load();
        if (gameData == null)
        {
            //If this is the first time you open the game than no gamedata will exist, therefor we need to create a new GameData
            gameData = new GameData();
        }

    }
}
