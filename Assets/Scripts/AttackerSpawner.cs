using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] BoardPiece[] attackers;
    [SerializeField] int lanesToSpawn = 6;
    [SerializeField] float preparationTime = 20f;
    [SerializeField] int difficultyMultiplier = 3;

    private bool spawn = true;
    private int difficultyLevel;
    private LevelController levelController;
    private int attackerTier;
    private float currentMinSpawnDelay;
    private float currentMaxSpawnDelay;

    void Awake() {
        attackerTier = 0;
        levelController = FindObjectOfType<LevelController>();
        difficultyLevel = PlayerPrefsController.GetDifficultyLevel();
        preparationTime -= difficultyLevel * difficultyMultiplier;

        currentMinSpawnDelay = minSpawnDelay;
        currentMaxSpawnDelay = maxSpawnDelay;
    }

    IEnumerator Start() {
        yield return new WaitForSeconds(preparationTime);
        while(spawn) {
            yield return new WaitForSeconds(
                Random.Range(
                    currentMinSpawnDelay,
                    currentMaxSpawnDelay
                )
            );
            Spawn();
        }
    }

    public void UpdateAttackerTier() {
        ++attackerTier;
        attackerTier = Mathf.Clamp(attackerTier, 0, attackers.Length);
        --currentMinSpawnDelay;
        currentMinSpawnDelay = Mathf.Clamp(
            currentMinSpawnDelay,
            1,
            minSpawnDelay
        );

        --currentMaxSpawnDelay;
        currentMaxSpawnDelay = Mathf.Clamp(
            currentMaxSpawnDelay,
            1,
            maxSpawnDelay
        );
    }

    public float GetPreparationTime() {
        return preparationTime;
    }

    public void StopSpawning() {
        spawn = false;
    }

    private void Spawn() {
        for(int i = 1; i <= lanesToSpawn; ++i) {
            int randomNumber = Random.Range(1, 6);
            if (i != randomNumber) { continue; }

            Vector2 spawnPosition = new Vector2(11, i);
            BoardPiece newAttacker = Instantiate(
                attackers[Random.Range(0, attackerTier)],
                spawnPosition,
                Quaternion.identity
            );

            Health newAttackerHealth = newAttacker.GetComponent<Health>();
            if (newAttackerHealth) {
                newAttackerHealth.AddHealth(
                    difficultyLevel
                    * difficultyMultiplier
                    * difficultyMultiplier
                );
            }

            newAttacker.transform.SetParent(transform);
            levelController.AttackerSpawned();
        }
    }
}
