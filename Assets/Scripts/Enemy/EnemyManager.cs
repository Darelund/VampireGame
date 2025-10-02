using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new();

    public List<GameObject> GetEnemiesList => enemies;

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
              
                Destroy(enemies[i].gameObject);
                enemies.RemoveAt(i);
                i--;
                //Maybe use a Queue or stack?
            }
        }
    }
}
