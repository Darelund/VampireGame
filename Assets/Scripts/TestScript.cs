using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private int intValue;

    private void Awake()
    {
        intValue = 20;
    }
}
