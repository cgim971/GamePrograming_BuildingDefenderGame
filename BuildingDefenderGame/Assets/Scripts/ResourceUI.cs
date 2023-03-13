using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
    private ResourcesTypeListSO resourceTypeList;
    private Dictionary<ResourcesTypeSO, Transform> resourceTypeTransformDictionary;

    private void Awake() {
        resourceTypeList = Resources.Load<ResourcesTypeListSO>("ScriptableObject/list/ResourcesTypeList");
        resourceTypeTransformDictionary = new Dictionary<ResourcesTypeSO, Transform>();

        Transform resourceTemplate = transform.Find("ResourcesTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourcesTypeSO resourceType in resourceTypeList.resourcesTypeList) {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            float offsetAmoount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmoount * index - 120, -50);
            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            resourceTypeTransformDictionary.Add(resourceType, resourceTransform);

            index++;
        }
    }

    private void Start() {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, EventArgs e) {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount() {
        foreach (ResourcesTypeSO resourceType in resourceTypeList.resourcesTypeList) {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);

            resourceTypeTransformDictionary[resourceType].Find("text").GetComponent<Text>().text = resourceAmount.ToString();
        }
    }
}
