using System.IO;
using UnityEngine;

public class JsonSaver : IFileSaver
{
    //path
    //directory
    //File
    //Application.persistentDataPath or Application.DataPath
    public string FileName { get; private set; } = "ScoreData.json";
    private string FullPath = Application.persistentDataPath;

    public JsonSaver()
    {
       // FullPath = Path.Combine(Application.persistentDataPath, FileName);
       InitializeDirectory();
    }
    private void InitializeDirectory()
    {
        if(!Directory.Exists(Path.GetDirectoryName(FullPath)))
        {
            Directory.CreateDirectory(FullPath);
        }
    }

    public void Save(GameData gameData)
    {
        Debug.Log(FullPath);

        //Make sure the json file exists
        var combinedPath = Application.persistentDataPath + "/" + FileName;
        Debug.Log(combinedPath);
       if (!File.Exists(combinedPath))
        {
            var fileStream = File.Create(Path.Combine(Application.persistentDataPath, FileName));
            //How does it give it the right name?
            fileStream.Close();
        }

        //Convert struct to json
        var jsonObject = JsonUtility.ToJson(gameData, true);
        Debug.Log(jsonObject);

        //Write to file
        File.WriteAllText(combinedPath, jsonObject);  
    }
    public GameData Load()
    {
        GameData gameData = new GameData();

        var combinedPath = Application.persistentDataPath + "/" + FileName;
        Debug.Log(combinedPath);
        if (!File.Exists(combinedPath))
        {
            Debug.LogError("Could not find a file to load");
            return null;
        }

            string jsonString = File.ReadAllText(combinedPath);

        gameData = JsonUtility.FromJson<GameData>(jsonString);
        return gameData;
    }

    public void DeleteAllFiles()
    {
        //TODO: delete files
    }
}
