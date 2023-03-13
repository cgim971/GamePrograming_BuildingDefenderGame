using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance { get; private set; }

    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        buildingTypeList = Resources.Load<BuildingTypeListSO>("ScriptableObject/List/BuildingTypeList");
        activeBuildingType = null;
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && activeBuildingType != null) {
            CreateHarvester(activeBuildingType.prefab);
        }
    }

    void CreateHarvester(Transform ts) {
        Instantiate(ts.gameObject, GetMouseWorldPosition(), Quaternion.identity);
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingTYpe) => activeBuildingType = buildingTYpe;

    public BuildingTypeSO GetActiveBuildingType() => activeBuildingType;
}
