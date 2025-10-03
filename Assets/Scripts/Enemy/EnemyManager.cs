using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new();

    public List<GameObject> GetEnemiesList => enemies;
    private List<GameObject> enemiesToRemove = new List<GameObject>();
    [SerializeField] private ObjectPoolManager objectPoolManager;

    private static EnemyManager instance;


    public static EnemyManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }


    public void UpdateAllEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<EnemyController>().UpdateEnemy();
            //TODO: Remove enemies here
            if(!enemies[i].GetComponent<EnemyHealth>().IsAlive)
            {

                //Destroy(enemies[i].gameObject);
                //enemies.RemoveAt(i);
                //i--;

                enemiesToRemove.Add(enemies[i]);
                //Maybe use a Queue or stack?
            }
        }

        if(enemiesToRemove.Count > 0)
        {
            for (int i = enemiesToRemove.Count - 1; i >= 0; i--)
            {
               // enemiesToRemove[i].GetComponent<EnemyHealth>().SetmaxHealth
                objectPoolManager.GetObjectPools["Enemy1"].GiveBackToPool(enemiesToRemove[i].GetComponent<ObjectToPool>());
                enemies.Remove(enemiesToRemove[i]);
            }
            //Do I have to clear? I have to right? The elements will still remain but will be missing their references?
            enemiesToRemove.Clear(); 
        }
      
    }
}
