using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //https://sv.wikipedia.org/wiki/Lista_%C3%B6ver_varelser_i_nordisk_folktro
    //BaseEnemy
    //Farm
    //Vättar
    //Gårdstomtar(farmyard gnomes)
    //Mara

    //Forest
    //Skogsrået
    //Troll
    //Älvor
    //Bysen
    //Myling

    //Water
    //Näcken
    //Bäckahästen
    //Sjörået

    //Nature
    //Rådare
    //Lyktgubbe
    //Vittrorna







    //Old way of doing it, Example:
    //Orc, Vampire, Skeleton

    //Usually you have a BaseHealth script on all enemies, nothing special
    //BaseHealth

    //Then you might have a BaseEnemy script that contains the enemies movement, attacking(range, melee), etc...
    //All in the same place
    //BaseEnemy
    //speed, animation

    //Then when you inherit
    //Orc
    //Vampire
    //Skeleton
    //etc...
    //All you have to do is change the inherited members from the BaseEnemy
    //Change the Move(), Rotate(), Attack(), Animate(), etc... methods

    //But what do you do when the BaseEnemy functions like a Controller containing x classes
    //How do I change EnemyMovement or EnemyAttack(EnemyShooter, what do you even call this?) when its not inherited?
    //We are supposed to create a class for each thing, but how do inherit if we do that?
    //EnemyMovement = OrcMovement, VampireMovement, etc...
    //EnemyShooter = OrcShooter, VampireShooter, etc...
    //And then we have Orc use OrcMovement and OrcShooter
    //but now we lose inheritance?

    //Do we make an abstract class/Interface?
    //IMoveable, IAttackable, IAnimateable


    //normal walk/run towards, teleport, around in circles, walk if player is not looking, Red rose(röda rosen)(Move when the player isn't looking), Skuggkull(Shadow Hill?)
    //Enemy states Idle, walk, run, attack, Flee
    //But in this game, only move(run/walk) towards?


    /*
     * Make EnemyShooter(rename that shit) to its own gameobject
     * EnemyMovement should be: Moveable
     * Player, and BaseEnemy uses an inherited class. PlayerMovement, OrcMovement, SkeletonMovement
     * 
     * 
     * Why does BaseEnemy even exist? Only for us to be able to group enemies into a list?????????
     */

    //OLD SOLUTION
    /*
     *   [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyShooter enemyShooter; //Could move into own GameObject
    [SerializeField] private EnemyHealth enemyHealth; //

    public void UpdateEnemy()
    {
        if (!enemyHealth.IsAlive) return;
        enemyMovement.UpdateMovement();
        enemyShooter.UpdateShooting();
    }
     */

    //New Solution


    [SerializeField] private Moveable movement;
    [SerializeField] private Rotatable rotatable;
    //[SerializeField] private EnemyShooter enemyShooter; //Moved to its own class
    [SerializeField] private EnemyHealth health; // Still here, should it still be here? We should only move if alive, but if we are dead then its deactivated and will be in the ObjectPool
    //So it won't Update regardless, right? Eh I will just leave it.

    public void UpdateEnemy()
    {
        if (!health.IsAlive) return;
        movement.UpdateMovement();
        rotatable.Rotate();
      //  enemyShooter.UpdateShooting();
    }
    public void AddMovement<T>() where T : Moveable
    {
       movement = gameObject.AddComponent<T>();
    }
    public void ResetEnemy()
    {
        health.Init();
    }
}
