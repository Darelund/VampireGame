using UnityEngine;

public interface IAttributable
{
    void AddScriptAttribute<T>() where T : Attribute, new();
    void AddPrefabAttribute(GameObject prefab);

}
