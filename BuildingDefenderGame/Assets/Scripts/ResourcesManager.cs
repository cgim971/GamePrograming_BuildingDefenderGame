using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {

    public static ResourcesManager Instance { get; private set; }

    private Dictionary<ResourcesTypeSO, int> resourceAmountDictionary;
    private ResourcesTypeListSO resourceTypeList;

    private void Awake() {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourcesTypeSO, int>();
        resourceTypeList = Resources.Load<ResourcesTypeListSO>("ScriptableObject/list/ResourcesTypeList");

        foreach (ResourcesTypeSO resourcesType in resourceTypeList.resourcesTypeList) {
            resourceAmountDictionary[resourcesType] = 0;
        }
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            AddResource(resourceTypeList.resourcesTypeList[0], 1);
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            AddResource(resourceTypeList.resourcesTypeList[1], 1);
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            AddResource(resourceTypeList.resourcesTypeList[2], 1);
        }
    }

    public void AddResource(ResourcesTypeSO resourceType, int count) {
        resourceAmountDictionary[resourceType] += count;
    }
}
