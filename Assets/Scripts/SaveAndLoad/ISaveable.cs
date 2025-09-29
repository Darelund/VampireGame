using UnityEngine;

public interface ISaveable<T>
{
    void Save(T data);
    void Load(T data)
    {
        //Whatever, I don't want to have to add Load to LoadData so I just add this comment in ISaveable to not have to do that
    }
}
