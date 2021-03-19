using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] Text volumeText;
    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDificulty = 1;
    [SerializeField] Text difficultyText;

    private MusicPlayer musicPlayer;
    private string[] difficultyLevelWords;

    void Start() {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeText.text = (volumeSlider.value * 100).ToString() + "%";
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultyLevelWords = new string[] { "Easy", "Normal", "Hard" };
        difficultySlider.value = PlayerPrefsController.GetDifficultyLevel();
    }

    void Update() {
        if(musicPlayer) {
            volumeText.text = (volumeSlider.value * 100).ToString("#.0") + "%";
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else {
            Debug.Log("No music player found!");
        }

        difficultyText.text = difficultyLevelWords[(int)difficultySlider.value];
    }

    public void SaveDifficultySettings() {
        PlayerPrefsController.SetDifficultyLevel((int)difficultySlider.value);
    }

    public void SaveVolumeSettings() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDificulty;
        SaveVolumeSettings();
    }
}
