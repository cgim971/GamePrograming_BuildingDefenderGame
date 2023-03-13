using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour {
    private BuildingTypeListSO buildingTypeList;
    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;

    [SerializeField] private Sprite arrowSprite;
    private Transform arrowBtn;

    private void Awake() {
        buildingTypeList = Resources.Load<BuildingTypeListSO>("ScriptableObject/list/BuildingTypeList");
        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();

        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        int index = 0;

        arrowBtn = Instantiate(btnTemplate, transform);
        arrowBtn.gameObject.SetActive(true);

        float offsetAmoount = 160f;
        arrowBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmoount * index + 80, 80);
        arrowBtn.Find("image").GetComponent<Image>().sprite = arrowSprite;
        arrowBtn.GetComponent<Button>().onClick.AddListener(() => {
            BuildingManager.Instance.SetActiveBuildingType(null);
        });
        index++;


        foreach (BuildingTypeSO buildingType in buildingTypeList.buildingTypeList) {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmoount * index + 80, 80);
            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;
            btnTransform.GetComponent<Button>().onClick.AddListener(() => {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            btnTransformDictionary[buildingType] = btnTransform;

            index++;
        }
    }

    private void Update() {
        UpdateActiveBuildingTypeButton();
    }

    public void UpdateActiveBuildingTypeButton() {
        arrowBtn.Find("selected").gameObject.SetActive(false);

        foreach (BuildingTypeSO buildingType in btnTransformDictionary.Keys) {
            Transform btnTransform = btnTransformDictionary[buildingType];
            btnTransform.Find("selected").gameObject.SetActive(false);
        }

        BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType == null) {
            arrowBtn.Find("selected").gameObject.SetActive(true);
        }
        else {
            btnTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
        }
    }
}
