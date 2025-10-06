using UnityEngine;

public abstract class Factory<T> : MonoBehaviour
{
    [SerializeField] protected GameObject poolPrefab;
   // [SerializeField] protected EnemyBuilder poolPrefab;
    public abstract T CreateEntity(EnemyFactory.EnemyType enemyType);
}
