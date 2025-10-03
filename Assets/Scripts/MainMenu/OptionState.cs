using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionState : State, ISaveable<GameSettings>
{
    [SerializeField] private List<GameObject> optionPanels = new List<GameObject>();
    [SerializeField] private List<GameObject> optionBtns = new List<GameObject>();
    [SerializeField] private Color activeColor;
    [SerializeField] private Color disabledColor;



    [SerializeField] private SoundManager soundManager;



    [Header("Video")]
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle vsyncToggle;

    [Header("Sound")]
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeTextValue;




    private void SaveGameSettings(GameSettings gameSettings)
    {
        gameSettings.FullscreenEnabled = Screen.fullScreen;
        gameSettings.VSyncEnabled = vsyncToggle.isOn;


        gameSettings.MuteEnabled = soundManager.BackgroundMusic.mute;
        gameSettings.VolumeValue = soundManager.BackgroundMusic.volume;

    }

    public void SetActivePanel(int index)
    {
        optionPanels.ForEach(p => { 
            p.SetActive(false);
        });
        optionBtns.ForEach(b => {
            b.GetComponent<Image>().color = disabledColor;
        });

        optionBtns[index].GetComponent<Image>().color = activeColor;
        optionPanels[index].SetActive(true);
    }

    //TODO: Rename the method, it should be used to initialize to the right state when we first enter options panels, but also when close it
    public void InitOptionPanels()
    {
        SetActivePanel(0);
    }

    private void InitializeOptions(GameSettings gameSettings)
    {
        fullscreenToggle.isOn = gameSettings.FullscreenEnabled;
        //Screen.fullScreen = _gameSettings.FullscreenEnabled;

        SetFPS();

        vsyncToggle.isOn = gameSettings.VSyncEnabled;
        //QualitySettings.vSyncCount = (_gameSettings.VSyncEnabled ? 1 : 0);

        muteToggle.isOn = gameSettings.MuteEnabled;
        soundManager.ToggleMute(gameSettings.MuteEnabled);

        volumeTextValue.text = $"{gameSettings.VolumeValue * 100}";
        volumeSlider.value = gameSettings.VolumeValue;
       // soundManager.ChangeVolume(gameSettings.VolumeValue);
    }
    public void SetFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void SetFPS(int newFps = -1) => Application.targetFrameRate = newFps;
    public void SetVSync()
    {
        QualitySettings.vSyncCount = (vsyncToggle.isOn ? 1 : 0);
    }
    public void SetMute()
    {
        soundManager.ToggleMute(muteToggle.isOn);
    }
    public void SetVolume()
    {
        //volumeSlider.value = _gameSettings.VolumeValue;
        volumeTextValue.text = $"{volumeSlider.value * 100:000}";
        soundManager.ChangeVolume(volumeSlider.value);
    }

    public void Save(GameSettings data)
    {
        SaveGameSettings(data);
    }
    public void Load(GameSettings data)
    {
        InitializeOptions(data);
    }
}
