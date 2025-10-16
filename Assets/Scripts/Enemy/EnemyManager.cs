using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new();

    public List<GameObject> GetEnemiesList => enemies;
    private List<GameObject> enemiesToRemove = new List<GameObject>();
    [SerializeField] private ObjectPoolManager objectPoolManager;
    [SerializeField] private WaveManager waveManager;

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
            if (!enemies[i].GetComponent<EnemyHealth>().IsAlive)
            {

                enemiesToRemove.Add(enemies[i]);
            }
        }

        if (enemiesToRemove.Count > 0)
        {
            for (int i = enemiesToRemove.Count - 1; i >= 0; i--)
            {
                enemiesToRemove[i].GetComponent<ObjectToPool>().GiveBackToPool();
                enemies.Remove(enemiesToRemove[i]);
            }
            enemiesToRemove.Clear();
        }

    }

    public bool EnemiesExist()
    {
        return enemies.Count > 0;
    }
}
