using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : BoardPiece {
    [SerializeField] int damage;

    Health targetHealth;

    void Start() {
        base.Start();
        cost = 0;
    }

    void Update() {
        base.Update();

        RaycastHit2D targetInRange = Physics2D.Raycast(
            transform.position,
            Vector2.left,
            attackRange,
            targetLayer
        );

        if (targetInRange) {
            Debug.DrawRay(transform.position, Vector2.left * attackRange, Color.red);
            currentWalkSpeed = 0;
            targetHealth = targetInRange.transform.GetComponent<Health>();
            animator.SetBool("InAttackRange", true);
        }
        else {
            animator.SetBool("InAttackRange", false);
            targetHealth = null;
        }
    }

    public void Attack() {
        if (targetHealth) {
            targetHealth.TakeDamage(damage);
        }
    }

    public bool HasTarget() {
        return (targetHealth);
    }
}
