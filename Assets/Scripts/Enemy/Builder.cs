using System;
using System.Collections.Generic;
using UnityEngine;

public class Builder<T> where T : IAttributable
{
    private GameObject prefab;
    private readonly List<Action<T>> buildSteps = new();

    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public virtual Builder<T> WithScriptAttribute<TAttribute>() where TAttribute : Attribute, new()
    {
        buildSteps.Add(a => a.AddScriptAttribute<TAttribute>());
        return this;
    }
    public virtual Builder<T> WithPrefabAttribute(GameObject prefab)
    {
        buildSteps.Add(a => a.AddPrefabAttribute(prefab));
        return this;
    }
    public virtual T Build()
    {
        T instance = GameObject.Instantiate(prefab).GetComponent<T>();
        foreach (var step in buildSteps)
        {
            step?.Invoke(instance);
        }
        return instance;
    }
}