using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealthBar(float curr, float max)
    {
        slider.value = curr / max;
    }
}
