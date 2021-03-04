using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float attackRange;
    [SerializeField] int damage;

    float currentWalkSpeed;
    Animator animator;

    Health targetHealth;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        transform.Translate(Vector2.left * currentWalkSpeed * Time.deltaTime);

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

    public void SetWalkSpeed(float speed) {
        currentWalkSpeed = speed;
    }

    public void Attack() {
        if (targetHealth) {
            targetHealth.TakeDamage(damage);
        }
    }
}
