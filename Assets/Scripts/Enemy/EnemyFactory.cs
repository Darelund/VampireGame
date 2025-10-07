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
        //    ["RangeV�tte"] = new Factory<EnemyController>(new EnemyStrategy(Resources.Load<EnemyController>("Enemy"), { new OrbitMovement, ))
        //};
        //enemies = new()
        //{
        //    ["RangedV�tte"] = () => {
        //        Factory<EnemyController> enemyFactory = new();
        //        enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/V�tte.prefab").gameObject);
        //       return enemyFactory.builder.WithScriptAttribute<OrbitMovement>().WithPrefabAttribute(Resources.Load<EnemyController>("Weapons/RangedWeapon.prefab").gameObject).Build();
        //    },
        //    ["MeleeV�tte"] = () => {
        //        Factory<EnemyController> enemyFactory = new();
        //        enemyFactory.builder.SetPrefab(Resources.Load<EnemyController>("Enemies/V�tte.prefab").gameObject);
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
    
    //Han gjorde s� att Abstract factory inte �rvar av Mono utan har det i en dictionary
    //Ist�llet f�r casen d�r nere borde du ha en klass d�r du g�r flera enemies 
    //som har olika typer
    public EnemyController CreateEntity()
    {
        EnemyController enemy = null;
        //switch (enemyType)
        //{
        //    case EnemyType.RangeV�tte:
        //        _builder.SetPrefab(enemyPrefabs[0]);
        //        enemy = _builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[0]).Build();
        //        break;
        //    case EnemyType.MeleeV�tte:
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
//    RangeV�tte,
//    MeleeV�tte,
//    RangedLyktgubbe,
//    MeleeLyktgubbe
//}
