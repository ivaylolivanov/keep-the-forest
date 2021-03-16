using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] BoardPiece defenderPrefab;

    SpriteRenderer spriteRenderer;
    DefenderSpawner defenderSpawner;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach(var button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(84, 84, 84, 255);
        }

        spriteRenderer.color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
