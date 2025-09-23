using System.Collections.Generic;
using System.Linq;
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
    public Score score = new Score();

    private IFileSaver _fileSaver;
    private List<ISaveable> saveableElements = new List<ISaveable>();

    private void Awake()
    {
        if (instance != null) 
            Destroy(gameObject);

        instance = this;
        DontDestroyOnLoad(gameObject);
        _fileSaver = new JsonSaver();
        saveableElements = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).OfType<ISaveable>().ToList();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SaveScore();
        }
    }
    public void SaveScore()
    {
        
        foreach (var element in saveableElements)
        {
            element.Save(score);
        }
        //score.Name = "Bob"; //On player
        //score.Level = 1; // On Player Upgrade
        //score.Waves = 1; // On EnemySpawner
        //score.Time = new PlayedTime(0, 5, 46); //On GameManager
        //score.EnemiesKilled = 4; //On GameManager
        //score.ExperiencePoints = 55; // On Player Upgrade
        _fileSaver.Save(score);
    }
}
