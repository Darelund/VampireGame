using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = transform.parent.GetComponent<PlayerHealth>();
    }
}
