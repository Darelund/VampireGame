using UnityEngine;

public class EnemyFactory : Factory<EnemyController>
{
    [SerializeField] private Builder builder;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] weaponsPrefabs;
    
    //Han gjorde s� att Abstract factory inte �rvar av Mono utan har det i en dictionary
    //Ist�llet f�r casen d�r nere borde du ha en klass d�r du g�r flera enemies 
    //som har olika typer
    public override EnemyController CreateEntity(EnemyType enemyType)
    {
        EnemyController enemy = null;
        switch (enemyType)
        {
            case EnemyType.RangeV�tte:
                builder.SetPrefab(enemyPrefabs[0]);
                enemy = builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[0]).Build();
                break;
            case EnemyType.MeleeV�tte:
                builder.SetPrefab(enemyPrefabs[0]);
                enemy = builder.AddMovement<MoveTowardsMovement>().AddWeapon(weaponsPrefabs[1]).Build();
                break;
            case EnemyType.RangedLyktgubbe:
                builder.SetPrefab(enemyPrefabs[1]);
                enemy = builder.AddMovement<OrbitMovement>().AddWeapon(weaponsPrefabs[0]).Build();
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
public class EnemyStrategy<T>
{
    public string EnemyName;
    public T Movement;
    public GameObject Weapon;

}
public enum EnemyType
{
    RangeV�tte,
    MeleeV�tte,
    RangedLyktgubbe,
    MeleeLyktgubbe
}
