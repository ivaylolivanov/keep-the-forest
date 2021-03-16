using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : BoardPiece {

    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject projectile;

    RaycastHit2D targetInRange;

    void Start() {
        base.Start();
        currentWalkSpeed = 0f;
    }

    void Update() {
        base.Update();

        if(targetInRange) {
            animator.SetBool("Attack", true);
        }
        else {
            animator.SetBool("Attack", false);
        }
    }

    void FixedUpdate() {
        targetInRange = Physics2D.Raycast(
            attackPoint.position,
            Vector2.right,
            attackRange,
            targetLayer
        );
    }

    public override void SetMovingDirectionToRunning() {
        movingDirection = Vector2.left;
    }

    public void Attack() {
        Instantiate(projectile, attackPoint.position, Quaternion.identity);
    }
}
