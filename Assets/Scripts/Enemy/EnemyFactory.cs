using UnityEngine;

public class EnemyFactory : Factory<EnemyController>
{
    [SerializeField] private Builder builder;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] weaponsPrefabs;
    

    public override EnemyController CreateEntity(EnemyType enemyType)
    {
        EnemyController enemy = null;
        switch (enemyType)
        {
            case EnemyType.RangeVätte:
                builder.SetPrefab(enemyPrefabs[0]);
                enemy = builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[0]).Build();
                break;
            case EnemyType.MeleeVätte:
                builder.SetPrefab(enemyPrefabs[0]);
                enemy = builder.AddMovement<MoveTowardsMovement>().AddWeapon(weaponsPrefabs[0]).Build();
                break;
            case EnemyType.RangedLyktgubbe:
                builder.SetPrefab(enemyPrefabs[1]);
                enemy = builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[1]).Build();
                break;
            case EnemyType.MeleeLyktgubbe:
                builder.SetPrefab(enemyPrefabs[1]);
                enemy = builder.AddMovement<MoveTowardsMovement>().AddWeapon(weaponsPrefabs[1]).Build();
                break;
            default:
                break;
        }



        return enemy;
    }
}
public enum EnemyType
{
    RangeVätte,
    MeleeVätte,
    RangedLyktgubbe,
    MeleeLyktgubbe
}
