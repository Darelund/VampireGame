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

    public void Save(Score score)
    {
        Debug.Log(FullPath);

        //Make sure the json file exists
        var combinedPath = Path.Combine(Application.persistentDataPath, FileName);
        Debug.Log(combinedPath);
       if (!File.Exists(combinedPath))
        {
            var fileStream = File.Create(Path.Combine(Application.persistentDataPath, FileName));
            //How does it give it the right name?
            fileStream.Close();
        }

        //Convert struct to json
        var jsonObject = JsonUtility.ToJson(score, true);

        //Write to file
        File.WriteAllText(combinedPath, jsonObject);  
    }
    public Score Load(string path)
    {
        Score score = new Score();

        string jsonString = File.ReadAllText(path);

        score = JsonUtility.FromJson<Score>(jsonString);
        return score;
    }
}
