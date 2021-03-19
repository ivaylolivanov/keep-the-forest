using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {
    [SerializeField] BoardPiece defenderPrefab;

    SpriteRenderer spriteRenderer;
    DefenderSpawner defenderSpawner;
    Text costText;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        costText = GetComponentInChildren<Text>();
        if (costText) {
            costText.text = defenderPrefab.GetCost().ToString();
        }
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
