using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Level time in SECONDS")]
    [SerializeField] float spawnDuration = 10;
    [SerializeField] float attackerTierUpPeriod = 30f;
    [SerializeField] Text announcementText;
    [SerializeField] float announcementDelay;

    private float levelDuration;
    private Slider timerSlider;
    private bool levelFinished;
    private AttackerSpawner attackerSpawner;

    private float nextAttackerTierUpdate;
    private float prepTime;

    void Start() {
        announcementText.enabled = false;
        attackerSpawner = FindObjectOfType<AttackerSpawner>();

        prepTime = attackerSpawner.GetPreparationTime();
        levelDuration = prepTime + spawnDuration;

        levelFinished = false;

        timerSlider = GetComponent<Slider>();
        timerSlider.value = Time.timeSinceLevelLoad / levelDuration;

        nextAttackerTierUpdate = Time.timeSinceLevelLoad
            + attackerTierUpPeriod
            + prepTime;

        StartCoroutine(Announce("Place your defenders", announcementDelay));
        StartCoroutine(
            DelayedAnnounce(
                "Attackers incoming",
                prepTime,
                announcementDelay
            )
        );
    }

    void Update() {
        timerSlider.value = Time.timeSinceLevelLoad / levelDuration;

        if(attackerSpawner != null && levelFinished) {
            attackerSpawner.StopSpawning();
            return;
        }

        if(Time.timeSinceLevelLoad >= nextAttackerTierUpdate) {
            StartCoroutine(
                Announce(
                    "Attackers grow stronger!",
                    announcementDelay
                )
            );

            attackerSpawner.UpdateAttackerTier();
            nextAttackerTierUpdate = Time.timeSinceLevelLoad
                + attackerTierUpPeriod;
        }

        levelFinished = (Time.timeSinceLevelLoad >= levelDuration);
    }

    public bool HasFinished() {
        return levelFinished;
    }

    private IEnumerator DelayedAnnounce(
        string message,
        float delayTime,
        float displayTime
    ) {
        yield return new WaitForSeconds(delayTime);
        announcementText.text = message;
        announcementText.enabled = true;
        yield return new WaitForSeconds(displayTime);
        announcementText.enabled = false;
    }

    private IEnumerator Announce(string message, float delay) {
        announcementText.enabled = true;
        announcementText.text = message;
        yield return new WaitForSeconds(delay);
        announcementText.enabled = false;
    }
}
