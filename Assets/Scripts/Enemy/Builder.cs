using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    private GameObject prefab;
    //private readonly List<Action<EnemyController>> buildsteps = new();
    private Action<EnemyController> moveable;

    private GameObject weapon;


    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }
    //public Builder WithAttribute<T>() where T: EnemyAttribute
    //{
    //    buildsteps.Add(enemy => enemy.AddAttribute<T>());
    //        return this;
    //}
    //public EnemyController Build()
    //{
    //    Enemy enemy = Instantiate(prefab).GetComponent<Enemy>();
    //    foreach (var step in buildsteps)
    //    {
    //        step?.Invoke(enemy);
    //    }
    //    return;
    //}
    public Builder AddMovement<T>() where T : Moveable
    {
        moveable = (enemy => enemy.AddMovement<T>());
        return this;
    }
    public Builder AddWeapon(GameObject weaponPrefab)
    {
       weapon = weaponPrefab;
        return this;
    }

    public EnemyController Build()
    {
        GameObject newGameObject = Instantiate(prefab);
        Instantiate(weapon, newGameObject.transform);

        EnemyController enemyController = newGameObject.GetComponent<EnemyController>();
        moveable?.Invoke(enemyController);

        //foreach (var step in buildsteps)
        //{
        //    step?.Invoke(enemy);
        //}
        //return;
        return enemyController;
    }
}