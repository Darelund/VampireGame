using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Maybe make it generic
{
    [SerializeField] protected int poolSize;
    [SerializeField] protected bool automaticallyExpandPoolSize;
    [SerializeField] protected GameObject poolPrefab;
    [SerializeField] protected Transform poolParent;

    [SerializeField] private Factory<EnemyController> enemyFactory;


    protected Stack<GameObject> poolStack;

    //protected virtual void Awake()
    //{
    //    InitializePool();
    //}
    public virtual void InitializePool()
    {
        poolStack = new Stack<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
          //  int rndPick = Random.Range(0, poolPrefab.Length);
            var instance = Instantiate(poolPrefab, poolParent);

            instance.GetComponent<ObjectToPool>().Pool = this;
            poolStack.Push(instance);
            instance.SetActive(false);
        }


    }
    public virtual GameObject UsePool()
    {
        GameObject instance = null;
        if(poolStack.Count == 0)
        {
            Debug.Log("Pool is empty");
            if(automaticallyExpandPoolSize)
            {
               // int rndPick = Random.Range(0, poolPrefab.Length);
                instance = Instantiate(poolPrefab, poolParent);
                instance.GetComponent<ObjectToPool>().Pool = this;
            }
            else
            {
                Debug.Log("Not allowed to automatically expand size, null is returned");
            }
                return instance;
        }
        instance = poolStack.Pop();
        instance.SetActive(true);
        return instance;

    }
    public virtual void GiveBackToPool(ObjectToPool instance)
    {
        instance.gameObject.SetActive(false);
        poolStack.Push(instance.gameObject);
    }
}
