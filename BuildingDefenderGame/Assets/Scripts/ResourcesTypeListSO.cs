using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourcesTypeList")]
public class ResourcesTypeListSO : ScriptableObject {
    public List<ResourcesTypeSO> resourcesTypeList;
}
