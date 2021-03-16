using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
    [SerializeField] float expireTime;

    Animator animator;
    ResourcesDisplay resourcesDisplay;
    int amount;

    float expiresAt;

    void Start() {
        animator = GetComponent<Animator>();
        expiresAt = Time.time + expireTime;
    }

    void Update() {
        int thirdOfExpiration = (int)expiresAt - (int)(expiresAt / 3);

        if(Time.time >= thirdOfExpiration) {
            animator.SetBool("WillExpire", true);
        }

        if(Time.time > expiresAt) {
            Destroy(gameObject);
        }
    }

    void OnMouseDown() {
        resourcesDisplay.AddResources(amount);
        Destroy(gameObject);
    }

    public void SetAmount(int resourceAmount) {
        amount = resourceAmount;
    }

    public void SetResourcesDisplay(ResourcesDisplay display) {
        resourcesDisplay = display;
    }
}
