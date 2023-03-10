using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;

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

    }

    public void AddResource(ResourcesTypeSO resourceType, int count) {
        resourceAmountDictionary[resourceType] += count;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }


    public void SubResource(ResourcesTypeSO resourceType, int count) {
        resourceAmountDictionary[resourceType] -= count;
    }

    private void Test() {
        Debug.Log("???? : " + resourceAmountDictionary[resourceTypeList.resourcesTypeList[0]]);
        Debug.Log("?? : " + resourceAmountDictionary[resourceTypeList.resourcesTypeList[1]]);
        Debug.Log("?? : " + resourceAmountDictionary[resourceTypeList.resourcesTypeList[2]]);
    }

    public int GetResourceAmount(ResourcesTypeSO resourceType) {
        return resourceAmountDictionary[resourceType];
    }
}
