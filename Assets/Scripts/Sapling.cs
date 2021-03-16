using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : BoardPiece {
    [SerializeField] int initialResource2give = 10;
    [SerializeField] float initialResourcesSpawnPeriod = 15f;
    [SerializeField] float growPeriod = 60f;
    [SerializeField] List<Resource> resources;
    [SerializeField] List<Sprite> grownStates;

    ResourcesDisplay resourcesDisplay;
    SpriteRenderer spriteRenderer;

    int resources2give;
    float resourcesSpawnPeriod;

    float nextResourcesSpawn;
    float nextGrowTime;

    int currentGrowState;

    void Start() {
        resources2give = initialResource2give;
        resourcesSpawnPeriod = initialResourcesSpawnPeriod;

        nextGrowTime = Time.time + growPeriod;
        nextResourcesSpawn = Time.time + resourcesSpawnPeriod;

        resourcesDisplay = FindObjectOfType<ResourcesDisplay>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        currentGrowState = 0;
    }

    void Update() {
        if(Time.time > nextResourcesSpawn) {
            Resource newResource = Instantiate(
                resources[Random.Range(0, resources.Count)],
                transform.position,
                Quaternion.identity
            ) as Resource;

            newResource.transform.SetParent(transform);

            newResource.SetAmount(resources2give);
            newResource.SetResourcesDisplay(resourcesDisplay);

            nextResourcesSpawn = Time.time + resourcesSpawnPeriod;
        }

        if(Time.time > nextGrowTime && currentGrowState < grownStates.Count) {
            spriteRenderer.sprite = grownStates[currentGrowState++];
            ++resources2give;
            resourcesSpawnPeriod -= 2;
            nextGrowTime = Time.time + growPeriod;
        }
    }
}
