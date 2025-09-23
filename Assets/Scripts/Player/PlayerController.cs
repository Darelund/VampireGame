using UnityEngine;

public class PlayerController : MonoBehaviour, ISaveable
{
    public string Name;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotater playerRotater;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerUpgrade playerUpgrade;


    public PlayerMovement GetPlayerMovement => playerMovement;
    public PlayerShooter GetPlayerShooter => playerShooter;

    public PlayerHealth GetPlayerHealth => playerHealth;

    public void Save(Score score)
    {
        score.Name = Name;
        score.Level = playerUpgrade.GetCurrentLevel;
        score.ExperiencePoints = playerUpgrade.GetTotalExperiencePoints;
    }   

    public void UpdatePlayer()
    {
        playerMovement.UpdateMovement();
        playerRotater.Rotate();
        playerShooter.UpdateShooting();
        cameraFollow.LateUpdateCamera();
    }
}
