using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Maybe make it generic
{
    [SerializeField] protected int poolSize;
    [SerializeField] protected bool automaticallyExpandPoolSize;
    //[SerializeField] protected GameObject poolPrefab;
    [SerializeField] protected Transform poolParent;

    [SerializeField] private string enemyToSpawn; //Should I really use a string?... No... But I love strings.
    [SerializeField] private EnemyFactory enemyFactory;
    //[SerializeField] private EnemyType enemyType;

    protected Stack<ObjectToPool> poolStack;

    //protected virtual void Awake()
    //{
    //    InitializePool();
    //}
    public virtual void InitializePool()
    {
        poolStack = new Stack<ObjectToPool>();

        for (int i = 0; i < poolSize; i++)
        {
          //  int rndPick = Random.Range(0, poolPrefab.Length);
            var instance = enemyFactory.enemies[enemyToSpawn]?.Invoke().GetComponent<ObjectToPool>();
            instance.gameObject.transform.SetParent(poolParent, false);

            instance.GetComponent<ObjectToPool>().Pool = this;
            poolStack.Push(instance);
            instance.gameObject.SetActive(false);
        }


    }
    public virtual ObjectToPool UsePool()
    {
        ObjectToPool instance = null;
        if(poolStack.Count == 0)
        {
            Debug.Log("Pool is empty");
            if(automaticallyExpandPoolSize)
            {
                // int rndPick = Random.Range(0, poolPrefab.Length);
                instance = enemyFactory.enemies[enemyToSpawn]?.Invoke().GetComponent<ObjectToPool>();
                instance.GetComponent<ObjectToPool>().Pool = this;
            }
            else
            {
                Debug.Log("Not allowed to automatically expand size, null is returned");
            }
                return instance;
        }
        instance = poolStack.Pop();
        instance.gameObject.SetActive(true);
        return instance;

    }
    public virtual void GiveBackToPool(ObjectToPool instance)
    {
        instance.gameObject.SetActive(false);
        poolStack.Push(instance);
    }
}
