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
            ["RangedV�tte"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/V�tte").gameObject);
                return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon")).Build();
            },
            ["MeleeV�tte"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/V�tte").gameObject);
                return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon").gameObject).Build();
            },
            ["RangedLyktgubbe"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/RangedLyktgubbe").gameObject);
                return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/RangedWeapon").gameObject).Build();
            },
            ["MeleeLyktgubbe"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/MeleeLyktgubbe").gameObject);
                return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/ElectricWeapon").gameObject).Build();
            },
            ["MeleeMyling"] = () =>
            {
                Factory<EnemyController> enemyFactory = new();
                enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/MeleeMyling").gameObject);
                return enemyFactory.builder.WithScriptAttribute<CrawlingMovement>().WithScriptAttribute<Rotatable>().WithPrefabAttribute(Resources.Load<GameObject>("Weapons/ElectricWeapon").gameObject).Build();
            }
        };
    }
}
//public class EnemyStrategy
//{
//  //  public string EnemyName = "No name";
//    public GameObject EnemyPrefab;
//    public List<Attribute> ScriptAttributes = new();
//    public List<GameObject> PrefabAttributes = new();
