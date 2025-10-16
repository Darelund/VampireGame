using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //I am getting them through code instead, might change that later
    //[SerializeField] private GameObject[] enemyPrefabs;
    //[SerializeField] private GameObject[] weaponsPrefabs;

    public Dictionary<string, Func<EnemyController>> enemies = new();

    private static int meleeCount = 0;
    private static int rangedCount = 0;


    public void Awake()
    {
        enemies = new()
        {
            ["RangedVätte"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Vätte").gameObject);
                return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon")).Build();
            },
            ["MeleeVätte"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Vätte").gameObject);
                return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon").gameObject).Build();
            },
            ["RangedLyktgubbe"] = () =>
            {
                rangedCount++;
                Debug.Log($"Created another ranged one, current count: {rangedCount}");
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/RangedLyktgubbe").gameObject);
                return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon").gameObject).Build();
            },
            ["MeleeLyktgubbe"] = () =>
            {
                meleeCount++;
                Debug.Log($"Created another melee one, current count: {meleeCount}");
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/MeleeLyktgubbe").gameObject);
                return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/ElectricWeapon").gameObject).Build();
            },
        };
    }
}
//public class EnemyStrategy
//{
//  //  public string EnemyName = "No name";
//    public GameObject EnemyPrefab;
//    public List<Attribute> ScriptAttributes = new();
//    public List<GameObject> PrefabAttributes = new();
