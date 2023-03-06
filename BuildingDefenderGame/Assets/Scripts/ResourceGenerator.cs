using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour {
    private BuildingTypeSO buildingType;
    private float timer;
    private float timerMax;

    private void Awake() {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        timer = timerMax = buildingType.resourceGeneratorData.timerMax;

    }

    private void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer += timerMax;
            ResourcesManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);
        }
    }
}
