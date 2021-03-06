using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int initialHitPoints;

    int currentHitPoints;
    Animator animator;

    void Start() {
        currentHitPoints = initialHitPoints;
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(currentHitPoints <= 0 && ! animator.GetBool("Defeated")) {
            Defeated();
        }
    }

    public void TakeDamage(int dmg) {
        currentHitPoints -= dmg;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, initialHitPoints);
    }

    private void Defeated() {
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
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
