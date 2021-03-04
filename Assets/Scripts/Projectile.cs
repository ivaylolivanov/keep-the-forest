using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] int damage;
    [SerializeField] float speed;

    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col) {
        Health attackerHealth = col.gameObject.GetComponent<Health>();

        if(attackerHealth) {
            attackerHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Health attackerHealth = col.GetComponent<Health>();

        if(attackerHealth) {
            attackerHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
