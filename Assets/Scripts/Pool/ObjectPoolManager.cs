using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private PoolData[] poolData;
    public PoolData[] GetPools => poolData;
    private bool isPooles = false;


   
    public void InitializeAllPooles()
    {
        if (isPooles) return;
        isPooles = true;
        //Maybe each pool should initialize itself? Well lets initialize them all here.
        foreach (var pool in poolData)
        {
            pool.ObjectPool.InitializePool();
            //objectPoolDictionary.Add(pool.Name, pool.ObjectPool);
        }
    }

}
[Serializable]
public class PoolData
{
    public string Name; //Key
    public ObjectPool ObjectPool;
}
