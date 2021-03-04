using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] GameObject attackerObject;

    private bool spawn = true;

    IEnumerator Start() {
        while(spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }

    private void Spawn() {
        Vector2 spawnPosition = new Vector2(11, Random.Range(1, 6));
        Instantiate(attackerObject, spawnPosition, Quaternion.identity);
    }
}
