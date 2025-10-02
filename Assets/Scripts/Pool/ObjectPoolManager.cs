using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private PoolData[] poolData;
    [SerializeField] private Dictionary<string, ObjectPool> objectPoolDictionary = new();
    public Dictionary<string, ObjectPool> GetObjectPools => objectPoolDictionary;


    private void Awake()
    {
        InitializeAllPoles();
    }
    private void InitializeAllPoles()
    {
        //Maybe each pool should initialize itself? Well lets initialize them all here.
        foreach (var pool in poolData)
        {
            pool.ObjectPool.InitializePool();
            objectPoolDictionary.Add(pool.Name, pool.ObjectPool);
        }
    }

}
[Serializable]
public class PoolData
{
    public string Name; //Key
    public ObjectPool ObjectPool;
}
