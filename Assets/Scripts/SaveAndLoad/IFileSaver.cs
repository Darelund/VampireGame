using UnityEngine;

public interface IFileSaver<T>
{
    string FileName { get; set; }
    void Save(T data);
    T Load();
    void DeleteAllFiles();
}
