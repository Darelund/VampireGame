using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //BaseEnemy
    //Farm
    //Vättar
    //Gårdstomtar(farmyard gnomes)

    //Forest
    //Skogsrået
    //Troll
    //Älvor
    //Bysen

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


    //normal walk/run towards, teleport, around in circles, 
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
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyShooter enemyShooter; //Could move into own GameObject
    [SerializeField] private EnemyHealth enemyHealth; //

    public void UpdateEnemy()
    {
        if (!enemyHealth.IsAlive) return;
        enemyMovement.UpdateMovement();
        enemyShooter.UpdateShooting();
    }
}
