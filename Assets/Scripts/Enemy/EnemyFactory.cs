using UnityEngine;

public class EnemyFactory : Factory<EnemyController>
{
    public Builder builder;
    public GameObject prefab;
   public enum EnemyType
    {
        RangeVätte,
        MeleeVätte,
        RangedLyktgubbe,
        MeleeLyktgubbe
    }

    public override EnemyController CreateEntity(EnemyType enemyType)
    {
        EnemyController enemy = null;
        builder.SetPrefab(prefab);
        switch (enemyType)
        {
            case EnemyType.RangeVätte:
                //enemy = builder.AddMovement(new OrbitMovement);
                break;
            case EnemyType.MeleeVätte:
                break;
            case EnemyType.RangedLyktgubbe:
                break;
            case EnemyType.MeleeLyktgubbe:
                break;
            default:
                break;
        }



        return null;
    }
}
