using System.IO;
using UnityEngine;

public class JsonSaver<T> : IFileSaver<T> where T : new()
{
    //path
    //directory
    //File
    //Application.persistentDataPath or Application.DataPath
    public string FileName { get; set; } = "ScoreData.json";
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

    public void Save(T gameData)
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
    public T Load()
    {
        T data = new T();

        var combinedPath = Application.persistentDataPath + "/" + FileName;
        Debug.Log(combinedPath);
        if (!File.Exists(combinedPath))
        {
            Debug.Log("Could not find a file to load, so I create one");

            var fileStream = File.Create(Path.Combine(Application.persistentDataPath, FileName));
            //How does it give it the right name?
            fileStream.Close();
        }

            string jsonString = File.ReadAllText(combinedPath);
        Debug.Log(jsonString);
        data = JsonUtility.FromJson<T>(jsonString);
        return data;
    }

    public void DeleteAllFiles()
    {
        //TODO: delete files
    }
}
