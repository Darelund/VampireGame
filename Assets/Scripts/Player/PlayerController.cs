using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISaveable
{

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotater rotater;
    //[SerializeField] private BaseWeapon playerShooter;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerUpgrade playerUpgrade;

    //TODO: Add maybe an event for when an ability gets changed



    //private void PlayerController_OnChangeAbility(Dictionary<string, PlayerStat> stats)
    //{

    //}
    private void Start()
    {
        //Initialize All scripts
        //playerHealth.SetmaxHealth(playerUpgrade.AbilityUpgrades["Health"].floatData);
        playerUpgrade.OnChangeAbility += playerHealth.PlayerHealth_OnValuesChanged;
        playerUpgrade.OnChangeAbility += playerMovement.PlayerMovement_OnValuesChanged;
        playerUpgrade.FireChangeAbility();
    }

    public void Save(GameData score)
    {
        var newestScore = score.scores[(score.scores.Count - 1)];
        newestScore.Level = playerUpgrade.GetCurrentLevel;
        newestScore.ExperiencePoints = playerUpgrade.GetTotalExperiencePoints;
    }   

    public void UpdatePlayer()
    {
        playerMovement.UpdateMovement();
        rotater?.Rotate();
        //playerShooter.UpdateUsingWeapon();
    }
    public void LateUpdatePlayer()
    {
        cameraFollow?.LateUpdateCamera();
    }
}
