using UnityEngine;

public interface IFileSaver
{
    string FileName { get; }
    void Save(GameData score);
    GameData Load();
    void DeleteAllFiles();
}
