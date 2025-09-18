using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotater playerRotater;
    [SerializeField] private PlayerShooter playerShooter;

    public void UpdatePlayer()
    {
        playerMovement.UpdateMovement();
        playerRotater.Rotate();
        playerShooter.UpdateShooting();
    }
}
