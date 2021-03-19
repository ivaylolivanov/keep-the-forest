using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour {
    [SerializeField] protected int cost = 100;
    [SerializeField] protected LayerMask targetLayer;
    [SerializeField] protected float attackRange;

    protected float slowExpirationTimer = 0;
    protected float currentWalkSpeedSlow = 0;
    protected float currentWalkSpeed = 0f;
    protected Vector2 movingDirection;
    protected Animator animator;
    protected bool canAttack = true;

    public void Start () {
        animator = GetComponent<Animator>();
        movingDirection = Vector2.left;
    }

    public void Update () {
        if(Time.time > slowExpirationTimer) {
            currentWalkSpeedSlow = 1;
        }

        transform.Translate(
            movingDirection
            * currentWalkSpeed * currentWalkSpeedSlow
            * Time.deltaTime
        );
    }

    public void SetCanAttack(bool canAttack) {
        this.canAttack = canAttack;
    }

    public int GetCost() {
        return cost;
    }

    public virtual void SetMovementSlow(float amount) {
        currentWalkSpeedSlow = amount;
    }

    public virtual void AddMovementSlowTime(float time) {
        slowExpirationTimer = Time.time + time;
    }

    public virtual void SetMovingDirectionToRunning() {
        movingDirection = Vector2.right;
        movingDirection.y = Random.Range(-1, 1);
    }

    public virtual void SetWalkSpeed(float speed) {
        currentWalkSpeed = speed;
    }
}
