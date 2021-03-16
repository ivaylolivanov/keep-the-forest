using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] BoardPiece[] attackers;

    private bool spawn = true;
    private LevelController levelController;

    void Awake() {
        levelController = FindObjectOfType<LevelController>();
    }

    IEnumerator Start() {
        while(spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }

    public void StopSpawning() {
        spawn = false;
    }

    private void Spawn() {
        Vector2 spawnPosition = new Vector2(11, Random.Range(1, 6));
        BoardPiece newAttacker = Instantiate(
            attackers[Random.Range(0, attackers.Length)],
            spawnPosition,
            Quaternion.identity
        );

        newAttacker.transform.SetParent(transform);
        levelController.AttackerSpawned();
    }
}
