using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    [SerializeField] AudioClip splashScreenSound;
    [SerializeField] AudioClip backgroundLoopSound;

    AudioSource audioSource;

    void Start() {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
        StartCoroutine(PlayMusic());
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    public void Pause() {
        audioSource.Pause();
    }

    public void Resume() {
        audioSource.UnPause();
    }

    private IEnumerator PlayMusic() {
        audioSource.clip = splashScreenSound;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.loop = true;
        audioSource.clip = backgroundLoopSound;
        audioSource.Play();
    }
}
