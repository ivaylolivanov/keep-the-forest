using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : BoardPiece {

    [SerializeField] Transform attackPoint;
    [SerializeField] int hitPoints;
    [SerializeField] LayerMask attackersLayer;
    [SerializeField] float attackRange;
    [SerializeField] GameObject projectile;

    float currentWalkSpeed = 0f;
    Vector2 movingDirection;
    Animator animator;

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
            attackPoint.position,
            Vector2.right,
            attackRange,
            attackersLayer
        );

        if(targetInRange) {
            animator.SetBool("Attack", true);
        }
        else {
            animator.SetBool("Attack", false);
        }
    }

    public override void SetMovingDirectionToRunning() {
        movingDirection = Vector2.left;
    }

    public override void SetWalkSpeed(float speed) {
        currentWalkSpeed = speed;
    }

    public void Attack() {
        Instantiate(projectile, attackPoint.position, Quaternion.identity);
    }
}
