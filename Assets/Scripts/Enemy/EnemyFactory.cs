using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
   // private Builder _builder;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] weaponsPrefabs;

    //private Dictionary<string, Factory<EnemyController>> factories = new();
    public readonly Dictionary<string, Func<EnemyController>> enemies = new();


    public EnemyFactory()
    {
        //factories = new()
        //{
        //    ["RangeVätte"] = new Factory<EnemyController>(new EnemyStrategy(Resources.Load<EnemyController>("Enemy"), { new OrbitMovement, ))
        //};
        //enemies = new()
        //{
        //    ["RangedVätte"] = () => {
        //        Factory<EnemyController> enemyFactory = new();
        //        enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Vätte.prefab").gameObject);
        //       return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithPrefabAttribute(Resources.Load<EnemyController>("Weapons/RangedWeapon.prefab").gameObject).Build();
        //    },
        //    ["MeleeVätte"] = () => {
        //        Factory<EnemyController> enemyFactory = new();
        //        enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Vätte.prefab").gameObject);
        //       return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithPrefabAttribute(Resources.Load<EnemyController>("Weapons/RangedWeapon.prefab").gameObject).Build();
        //    },
        //    ["RangedLyktgubbe"] = () => {
        //        Factory<EnemyController> enemyFactory = new();
        //        enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Lyktgubbe.prefab").gameObject);
        //      return  enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithPrefabAttribute(Resources.Load<EnemyController>("Weapons/RangedWeapon.prefab").gameObject).Build();
        //    },
        //    ["RangedLyktgubbe"] = () => {
        //        Factory<EnemyController> enemyFactory = new();
        //        enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/Lyktgubbe.prefab").gameObject);
        //       return enemyFactory.builder.WithScriptAttribute<MoveTowardsMovement>().WithPrefabAttribute(Resources.Load<EnemyController>("Weapons/RangedWeapon.prefab").gameObject).Build();
        //    },
        //};
    }
    
    //Han gjorde så att Abstract factory inte ärvar av Mono utan har det i en dictionary
    //Istället för casen där nere borde du ha en klass där du gör flera enemies 
    //som har olika typer
    public EnemyController CreateEntity()
    {
        EnemyController enemy = null;
        //switch (enemyType)
        //{
        //    case EnemyType.RangeVätte:
        //        _builder.SetPrefab(enemyPrefabs[0]);
        //        enemy = _builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[0]).Build();
        //        break;
        //    case EnemyType.MeleeVätte:
        //        _builder.SetPrefab(enemyPrefabs[0]);
        //        enemy = _builder.AddMovement<MoveTowardsMovement>().AddWeapon(weaponsPrefabs[1]).Build();
        //        break;
        //    case EnemyType.RangedLyktgubbe:
        //        _builder.SetPrefab(enemyPrefabs[1]);
        //        enemy = _builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[0]).Build();
        //        break;
        //    case EnemyType.MeleeLyktgubbe:
        //        _builder.SetPrefab(enemyPrefabs[1]);
        //        enemy = _builder.AddMovement<MoveTowardsMovement>().AddWeapon(weaponsPrefabs[1]).Build();
        //        break;
        //    default:
        //        break;
        //}
        return enemy;
    }
}
//public class EnemyStrategy
//{
//  //  public string EnemyName = "No name";
//    public GameObject EnemyPrefab;
//    public List<Attribute> ScriptAttributes = new();
//    public List<GameObject> PrefabAttributes = new();


//    public EnemyStrategy(GameObject enemyPrefab, List<Attribute> scriptAttributes, List<GameObject> prefabAttributes)
//    {
//        EnemyPrefab = enemyPrefab;
//        ScriptAttributes = scriptAttributes;
//        PrefabAttributes = prefabAttributes;
//    }
//    //public GameObject Weapon;

//}
//public enum EnemyType
//{
//    RangeVätte,
//    MeleeVätte,
//    RangedLyktgubbe,
//    MeleeLyktgubbe
//}
