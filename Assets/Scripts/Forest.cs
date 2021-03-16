using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forest : MonoBehaviour {

    [SerializeField] int maxLives = 5;

    int currentLives;
    Text currentLivesText;
    LevelController levelController;

    void Start() {
        currentLives = maxLives;
        currentLivesText = GetComponent<Text>();
        levelController = FindObjectOfType<LevelController>();
        UpdateDamageDisplay();
    }

    void OnTriggerEnter2D(Collider2D attacker) {
        --currentLives;
        UpdateDamageDisplay();
        Destroy(attacker.gameObject);

        if(currentLives <= 0) {
            StartCoroutine(levelController.LoseCurrentLevel());
        }
    }

    private void UpdateDamageDisplay() {
        currentLives = Mathf.Clamp(currentLives, 0, maxLives);
        currentLivesText.text = currentLives.ToString();
    }
}
