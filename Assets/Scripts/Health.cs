using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int initialHitPoints;
    [SerializeField] bool instantDestroy = false;
    [SerializeField] float destroyDelay = 5f;

    int currentHitPoints;

    DefenderSpawner defenderSpawner;
    Animator animator;

    private bool isDefeated;
    private LevelController levelController;

    void Start() {
        currentHitPoints = initialHitPoints;
        animator = GetComponent<Animator>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        levelController = FindObjectOfType<LevelController>();
    }

    void Update() {
        if(currentHitPoints <= 0 && ! isDefeated) {
            if(instantDestroy) {
                Destroy(gameObject);
            }
            else {
                Defeated();
            }

            defenderSpawner.ClearGridPosition(transform.position);
        }
    }

    public void TakeDamage(int dmg) {
        currentHitPoints -= dmg;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, initialHitPoints);
    }

    private void Defeated() {
        isDefeated = true;

        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        BoardPiece boardPiece = GetComponent<BoardPiece>();
        if(boardPiece) {
            Collider2D coll = boardPiece.GetComponent<Collider2D>();
            boardPiece.SetMovingDirectionToRunning();
            animator.SetBool("Defeated", true);

            if(coll) {
                coll.enabled = false;
            }
        }

        Destroy(gameObject, destroyDelay);
    }

    void OnDestroy() {
        if (levelController == null) { return; }
        levelController.AttackerDefetead();
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
