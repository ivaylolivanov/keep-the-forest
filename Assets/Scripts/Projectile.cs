using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] int damage;
    [SerializeField] float speed;
    [Range(0.1f , 1)]
    [SerializeField] float slowAmount;
    [SerializeField] float slowPeriod;

    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col) {
        Health attackerHealth = col.gameObject.GetComponent<Health>();
        BoardPiece boardPiece = col.gameObject.GetComponent<BoardPiece>();

        if(attackerHealth) {
            attackerHealth.TakeDamage(damage);
        }

        if(boardPiece && (slowAmount != 0)) {
            boardPiece.SetMovementSlow(slowAmount);
            boardPiece.AddMovementSlowTime(slowPeriod);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Health attackerHealth = col.GetComponent<Health>();
        BoardPiece boardPiece = col.GetComponent<BoardPiece>();

        if(attackerHealth) {
            attackerHealth.TakeDamage(damage);
        }

        if(boardPiece && (slowAmount != 0)) {
            boardPiece.SetMovementSlow(slowAmount);
            boardPiece.AddMovementSlowTime(slowPeriod);
        }

        Destroy(gameObject);
    }
}
