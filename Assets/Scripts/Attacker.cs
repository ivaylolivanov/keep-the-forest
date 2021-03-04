using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [SerializeField] int hitPoints;

    float currentWalkSpeed;
    int currentHitPoints;

    void Start() {
        currentHitPoints = hitPoints;
    }

    void Update() {
        transform.Translate(Vector2.left * currentWalkSpeed * Time.deltaTime);

        if(currentHitPoints <= 0) {
            Die();
        }
    }

    public void SetWalkSpeed(float speed) {
        currentWalkSpeed = speed;
    }

    public void TakeDamage(int dmg) {
        currentHitPoints -= dmg;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, hitPoints);
    }

    private void Die() {
        Destroy(gameObject);
    }
}
