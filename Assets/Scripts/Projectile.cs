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
        Attacker attacker = col.gameObject.GetComponent<Attacker>();

        attacker.TakeDamage(damage);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        Attacker attacker = col.GetComponent<Attacker>();

        attacker.TakeDamage(damage);
        Destroy(gameObject);
    }
}
