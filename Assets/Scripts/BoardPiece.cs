using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardPiece : MonoBehaviour {

    public abstract void SetMovingDirectionToRunning();
    public abstract void SetWalkSpeed(float speed);
}
