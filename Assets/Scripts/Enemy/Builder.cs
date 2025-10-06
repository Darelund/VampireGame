using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Builder : MonoBehaviour
{
    private GameObject prefab;
    //private readonly List<Action<EnemyController>> buildsteps = new();
    private Moveable moveable;

    private BaseWeapon weapon;


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
        this.moveable = moveable;
        return this;
    }
    public Builder AddWeapon(BaseWeapon weapon)
    {
        this.weapon = weapon;
        return this;
    }

    public EnemyController Build()
    {
        GameObject newGameObject = Instantiate(prefab);

        EnemyController enemyController = newGameObject.GetComponent<EnemyController>();

        //foreach (var step in buildsteps)
        //{
        //    step?.Invoke(enemy);
        //}
        //return;
        return null;
    }
    private void AddMoveComponent()
    {

    }
}