using UnityEngine;

public class Factory<T> where T : IAttributable, new()
{
    public Builder<T> builder;
   // private EnemyStrategy enemyStrategy;

    public Factory()
    {
        builder = new Builder<T>();
        //this.enemyStrategy = enemyStrategy;
        //builder.SetPrefab(enemyStrategy.EnemyPrefab);
    }
    public void CreateEntity()
    {

    }
}
