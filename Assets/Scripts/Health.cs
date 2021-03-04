using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int initialHitPoints;

    int currentHitPoints;
    void Start() {
        currentHitPoints = initialHitPoints;
    }

    void Update() {
        if(currentHitPoints <= 0) {
            Die();
        }
    }

    public void TakeDamage(int dmg) {
        currentHitPoints -= dmg;
        currentHitPoints = Mathf.Clamp(currentHitPoints, 0, initialHitPoints);
    }

    private void Die() {
        Destroy(gameObject);
    }
}
