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

    void Start() {
        currentlyAliveAttackers = 0;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        levelLoader = FindObjectOfType<LevelLoader>();
        levelTimer = FindObjectOfType<GameTimer>();
    }

    private IEnumerator CompleteCurrentLevel() {
        if (winLabel != null) {
            winLabel.SetActive(true);
        }

        audioSource.Play();
        yield return new WaitForSeconds(nextLevelLoadDelay);
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
            && currentlyAliveAttackers == 0
        ) {
            StartCoroutine(CompleteCurrentLevel());
        }
    }

    public void AttackerSpawned() {
        ++currentlyAliveAttackers;
    }
}
