using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleDefender : BoardPiece {

    void Start() {
        base.Start();
    }

    void Update() {
        RaycastHit2D targetInRange = Physics2D.Raycast(
            transform.position,
            Vector2.right,
            attackRange,
            targetLayer
        );

        if(targetInRange) {
            animator.SetBool("Hide", true);
        }
        else {
            animator.SetBool("Hide", false);
        }

    }
}
