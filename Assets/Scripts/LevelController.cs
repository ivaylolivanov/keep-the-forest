using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float nextLevelLoadDelay = 5f;

    private AudioSource audioSource;
    private LevelLoader levelLoader;
    private GameTimer levelTimer;

    private int currentlyAliveAttackers;
    private MusicPlayer musicPlayer;

    void Start() {
        currentlyAliveAttackers = 0;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        levelLoader = FindObjectOfType<LevelLoader>();
        levelTimer = FindObjectOfType<GameTimer>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer) {
            musicPlayer.Resume();
        }
    }

    private IEnumerator CompleteCurrentLevel() {
        if (winLabel != null) {
            winLabel.SetActive(true);
        }

        audioSource.Play();
        if (musicPlayer) {
            musicPlayer.Pause();
        }
        yield return new WaitForSeconds(nextLevelLoadDelay);
        if (musicPlayer) {
            musicPlayer.Resume();
        }
        levelLoader.LoadNextScene();
    }

    public IEnumerator LoseCurrentLevel() {
        if(loseLabel != null) {
            loseLabel.SetActive(true);
        }

        while (Time.timeScale > 0) {
            Time.timeScale *= 0.3f;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void AttackerDefetead() {
        --currentlyAliveAttackers;
        if(
            levelTimer.HasFinished()
            && currentlyAliveAttackers <= 0
        ) {
            StartCoroutine(CompleteCurrentLevel());
        }
    }

    public void AttackerSpawned() {
        ++currentlyAliveAttackers;
    }
}
