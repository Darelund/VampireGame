using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public AudioSource AudioSource
    {
        get => audioSource;
        set => audioSource = value;
    }

    public void ToggleMute(bool isOn) => audioSource.mute = isOn;
    public void ChangeVolume(float newVolume) => audioSource.volume = newVolume;
}
