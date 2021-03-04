using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    float currentWalkSpeed;
    Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        transform.Translate(Vector2.left * currentWalkSpeed * Time.deltaTime);
    }

    public void SetWalkSpeed(float speed) {
        currentWalkSpeed = speed;
    }
}
