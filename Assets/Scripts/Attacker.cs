using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : BoardPiece {
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float attackRange;
    [SerializeField] int damage;

    float currentWalkSpeed;
    Vector2 movingDirection;
    Animator animator;

    Health targetHealth;

    void Start() {
        animator = GetComponent<Animator>();
        movingDirection = Vector2.left;
    }

    void Update() {
        transform.Translate(
            movingDirection
            * currentWalkSpeed
            * Time.deltaTime
        );

        RaycastHit2D targetInRange = Physics2D.Raycast(
            transform.position,
            Vector2.left,
            attackRange,
            targetLayer
        );

        if (targetInRange) {
            currentWalkSpeed = 0;
            targetHealth = targetInRange.transform.GetComponent<Health>();
            animator.SetBool("InAttackRange", true);
        }
        else {
            animator.SetBool("InAttackRange", false);
            targetHealth = null;
        }
    }

    public override void SetMovingDirectionToRunning() {
        movingDirection = Vector2.right;
    }

    public override void SetWalkSpeed(float speed) {
        currentWalkSpeed = speed;
    }

    public void Attack() {
        if (targetHealth) {
            targetHealth.TakeDamage(damage);
        }
    }
}
