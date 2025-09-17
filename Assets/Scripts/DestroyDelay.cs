using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    [SerializeField] private float delay;
    private void Awake()
    {
        Destroy(gameObject, delay);
    }
}
