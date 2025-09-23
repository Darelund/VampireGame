using UnityEngine;

public interface IFileSaver
{
    string FileName { get; }
    void Save(Score score);
    Score Load(string path);
}
