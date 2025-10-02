using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour //Maybe make it generic
{
    [SerializeField] private int poolSize;
    [SerializeField] private bool automaticallyExpandPoolSize;
    [SerializeField] private GameObject poolPrefab; //TODO: A system to have more than one object and control how many should spawn of each object
    [SerializeField] private Transform poolParent;




    private Stack<GameObject> poolStack;

    private void Awake()
    {
        InitializePool();
    }
    public void InitializePool()
    {
        poolStack = new Stack<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            var instance = Instantiate(poolPrefab, poolParent);

            instance.GetComponent<ObjectToPool>().Pool = this;
            poolStack.Push(instance);
            instance.SetActive(false);
        }


    }
    public GameObject UsePool()
    {
        GameObject instance = null;
        if(poolStack.Count == 0)
        {
            Debug.Log("Pool is empty");
            if(automaticallyExpandPoolSize)
            {
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
    public void GiveBackToPool(ObjectToPool instance)
    {
        instance.gameObject.SetActive(false);
        poolStack.Push(instance.gameObject);
    }
}
