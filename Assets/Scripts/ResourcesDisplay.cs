using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesDisplay : MonoBehaviour {
    [SerializeField] int initialResources = 10;
    [SerializeField] int maxResources = 10000;

    Text resourcesText;
    int currentResources;

    void Start() {
        currentResources = initialResources;
        resourcesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        resourcesText.text = currentResources.ToString();
    }

    public bool CanAfford(int amount) {
        return (amount <= currentResources);
    }

    public void AddResources(int resources) {
        currentResources += resources;
        currentResources = Mathf.Clamp(currentResources, 0, maxResources);
        UpdateDisplay();
    }

    public void SpendResources(int resources) {
        currentResources -= resources;
        currentResources = Mathf.Clamp(currentResources, 0, maxResources);
        UpdateDisplay();
    }
}
