using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private List<SoundData> soundData;

    private Dictionary<string, SoundData> soundDictionary;

    private static SoundManager instance;


    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    //Right now enemies, player, etc...(maybe more in the future)
    //Master Volume, Music Volume, Effects Volume, UI Volume

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
        InitSounds();
    }
    private void InitSounds()
    {
        soundDictionary = new Dictionary<string, SoundData>();

        foreach (var data in soundData)
        {
            soundDictionary[data.Name] = data;
        }
    }
    public AudioSource BackgroundMusic
    {
        get => backgroundMusic;
        set => backgroundMusic = value;
    }

    //Mute all sounds or only background music? Right now lets mute them all
    public void ToggleMute(bool isOn)
    {
        backgroundMusic.mute = isOn;

        for (int i = 0; i < soundData.Count; i++)
        {
            soundData[i].AudioSource.mute = isOn;
        }
    }
    public void ChangeVolume(float newVolume) => backgroundMusic.volume = newVolume;

    //Should I use Play or PlayOneShot? If many enemies call the same AudioSource maybe I should use PlayOneShot
    public void PlaySound(string SoundDataOwner, string audioClip)
    {
        if(soundDictionary.ContainsKey(SoundDataOwner))
        {
            var audioClipToPlay = soundDictionary[SoundDataOwner].Clips.Find(c => c.name == audioClip) ?? null;
            if(audioClipToPlay != null)
            {
                if(soundDictionary[SoundDataOwner].AudioSource.isPlaying)
                {
                    //Should I do something if it is already playing? What happens with the previous audio if I change the clip and play the new one
                    //before the previous one is done? Does the new one get queued or override the old one?
                }
                soundDictionary[SoundDataOwner].AudioSource.clip = audioClipToPlay;
                soundDictionary[SoundDataOwner].AudioSource.Play();
            }
        }
    }
    public void PlayRandomSoundFromSoundData(string SoundDataOwner)
    {
        if (soundDictionary.ContainsKey(SoundDataOwner))
        {
            var soundIndex = UnityEngine.Random.Range(0, soundDictionary[SoundDataOwner].Clips.Count);
            var audioClipToPlay = soundDictionary[SoundDataOwner].Clips[soundIndex];
            if (audioClipToPlay != null)
            {
                if (soundDictionary[SoundDataOwner].AudioSource.isPlaying)
                {
                    //Should I do something if it is already playing? What happens with the previous audio if I change the clip and play the new one
                    //before the previous one is done? Does the new one get queued or override the old one?
                }
                soundDictionary[SoundDataOwner].AudioSource.clip = audioClipToPlay;
                soundDictionary[SoundDataOwner].AudioSource.Play();
            }
        }
    }

    //To add a queue for audio clips if you want that
    //private AudioSource audioSource;
    //private List<AudioClip> audioClips = new List<AudioClip>();
    //private Queue<AudioClip> audioQueue = new();
    //private void PlayAudio(AudioClip audioClip)
    //{
    //    if (audioSource.isPlaying)
    //    {
    //        audioQueue.Enqueue(audioClip);
    //        return;
    //    }
    //    while(audioQueue.Count > 0)
    //    {
    //        if (audioSource.isPlaying) return;

    //        audioSource.clip = audioQueue.Dequeue();
    //        audioSource.Play();
    //    }
    //}
}
[Serializable]
public class SoundData
{
    public string Name;
    public AudioSource AudioSource;
    public List<AudioClip> Clips;
}
