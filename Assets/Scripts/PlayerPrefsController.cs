using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 2;

    public static void SetMasterVolume(float volume) {
        volume = Mathf.Clamp(volume, MIN_VOLUME, MAX_VOLUME);
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    }

    public static void SetDifficultyLevel(int difficultyLevel) {
        difficultyLevel = Mathf.Clamp(
            difficultyLevel,
            MIN_DIFFICULTY,
            MAX_DIFFICULTY
        );
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficultyLevel);
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetDifficultyLevel() {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
