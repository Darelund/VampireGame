using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotater playerRotater;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private PlayerHealth playerHealth;

    public PlayerMovement GetPlayerMovement => playerMovement;
    public PlayerShooter GetPlayerShooter => playerShooter;

    public PlayerHealth GetPlayerHealth => playerHealth;

    public void UpdatePlayer()
    {
        playerMovement.UpdateMovement();
        playerRotater.Rotate();
        playerShooter.UpdateShooting();
        cameraFollow.LateUpdateCamera();
    }
}
