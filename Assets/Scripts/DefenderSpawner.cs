using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    List<Vector2> takenPositions;

    BoardPiece defender;

    ResourcesDisplay resourcesDisplay;
    Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
        resourcesDisplay = FindObjectOfType<ResourcesDisplay>();

        takenPositions = new List<Vector2>();
    }

    void OnMouseDown() {
        Vector2 gridMousePosition = GetGridMousePosition();
        if(defender) {
            SpawnDefender(gridMousePosition);
        }
    }

    public void SetSelectedDefender(BoardPiece selectedDefender) {
        defender = selectedDefender;
    }

    public void ClearGridPosition(Vector2 position) {
        if(takenPositions.Contains(position)) {
            takenPositions.Remove(position);
        }
    }

    private void SpawnDefender(Vector2 spawnPosition) {
        if (!takenPositions.Contains(spawnPosition)) {

            int defenderCost = defender.GetCost();
            if (resourcesDisplay.CanAfford(defenderCost)) {
                resourcesDisplay.SpendResources(defenderCost);

                BoardPiece newDefender = Instantiate(
                    defender,
                    spawnPosition,
                    Quaternion.identity
                ) as BoardPiece;

                takenPositions.Add(spawnPosition);
            }
            else {
                // Do some kind of feedback
            }
        }
    }

    private Vector2 SnapToGrid(Vector2 RawWorldPosition) {
        int newX = Mathf.Max(1, Mathf.RoundToInt(RawWorldPosition.x));
        int newY = Mathf.Max(1, Mathf.RoundToInt(RawWorldPosition.y));

        return new Vector2(newX, newY);
    }

    private Vector2 GetGridMousePosition() {
        Vector2 gridMousePosition = SnapToGrid(
            mainCamera.ScreenToWorldPoint(
                Input.mousePosition
            )
        );

        return gridMousePosition;
    }
}
