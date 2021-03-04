using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : MonoBehaviour {

    [SerializeField] Transform attackPoint;
    [SerializeField] int hitPoints;
    [SerializeField] LayerMask attackersLayer;
    [SerializeField] float attackRange;
    [SerializeField] GameObject projectile;

    Animator animator;
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
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

    public void Attack() {
        Instantiate(projectile, attackPoint.position, Quaternion.identity);
    }
}
