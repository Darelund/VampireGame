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

    private IFileSaver _fileSaver;
    private List<ISaveable> saveableElements = new List<ISaveable>();

    private void Awake()
    {
        if (instance != null) 
            Destroy(gameObject);

        instance = this;
        _fileSaver = new JsonSaver();
        saveableElements = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).OfType<ISaveable>().ToList();
        gameData = new GameData();
        LoadGameData();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SaveGameData();
        }
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
        //gameData.scores.Add(new Score(1, "Bob", 1, 1, 0, 1, new PlayedTime(0, 0, 1)));
        //gameData.scores.Add(new Score(3, "Diva", 9999, 99, 9, 999, new PlayedTime(0, 10, 0)));
        //gameData.scores.Add(new Score(2, "Jesse", 546, 7, 2, 119, new PlayedTime(0, 0, 1)));
    }
}
