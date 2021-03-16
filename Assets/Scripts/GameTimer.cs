using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Level time in SECONDS")]
    [SerializeField] float levelDuration = 10;

    private Slider timerSlider;
    private bool levelFinished;

    private AttackerSpawner attackerSpawner;

    void Start() {
        levelFinished = false;
        timerSlider = GetComponent<Slider>();
        timerSlider.value = Time.timeSinceLevelLoad / levelDuration;
        attackerSpawner = FindObjectOfType<AttackerSpawner>();
    }

    void Update() {
        timerSlider.value = Time.timeSinceLevelLoad / levelDuration;

        levelFinished = (Time.timeSinceLevelLoad >= levelDuration);

        if(attackerSpawner != null && levelFinished) {
            attackerSpawner.StopSpawning();
        }
    }

    public bool HasFinished() {
        return levelFinished;
    }
}
