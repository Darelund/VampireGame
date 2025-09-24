using UnityEngine;

public class PlayerController : MonoBehaviour, ISaveable
{

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotater playerRotater;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerUpgrade playerUpgrade;


    public PlayerMovement GetPlayerMovement => playerMovement;
    public PlayerShooter GetPlayerShooter => playerShooter;

    public PlayerHealth GetPlayerHealth => playerHealth;

    public void Save(GameData score)
    {
        var newestScore = score.scores[(score.scores.Count - 1)];
        newestScore.Level = playerUpgrade.GetCurrentLevel;
        newestScore.ExperiencePoints = playerUpgrade.GetTotalExperiencePoints;
    }   

    public void UpdatePlayer()
    {
        playerMovement.UpdateMovement();
        playerRotater?.Rotate();
        playerShooter.UpdateShooting();
        cameraFollow?.LateUpdateCamera();
    }
}
