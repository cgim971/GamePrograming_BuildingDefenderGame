using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    private BuildingTypeListSO buildingTypeList;
    private int buildingIndex= 0;

    private void Start() {
        buildingTypeList = Resources.Load<BuildingTypeListSO>("ScriptableObject/List/BuildingTypeList");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            CreateHarvester(buildingTypeList.buildingTypeList[0].prefab);
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            CreateHarvester(buildingTypeList.buildingTypeList[1].prefab);
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            CreateHarvester(buildingTypeList.buildingTypeList[2].prefab);
        }

    }

    void CreateHarvester(Transform ts) {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        Instantiate(ts.gameObject, pos, Quaternion.identity);
    }


}
