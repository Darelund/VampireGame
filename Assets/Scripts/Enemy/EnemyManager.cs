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


    // Update is called once per frame
    public void UpdateAllEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<BaseEnemy>().UpdateEnemy();
        }
    }
}
