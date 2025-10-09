using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //I am getting them through code instead, might change that later
    //[SerializeField] private GameObject[] enemyPrefabs;
    //[SerializeField] private GameObject[] weaponsPrefabs;

    public readonly Dictionary<string, Func<EnemyController>> enemies = new();


    public EnemyFactory()
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
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Lyktgubbe").gameObject);
                return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon").gameObject).Build();
            },
            ["MeleeLyktgubbe"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Lyktgubbe").gameObject);
                return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon").gameObject).Build();
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
