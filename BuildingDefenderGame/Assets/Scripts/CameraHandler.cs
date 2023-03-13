using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCam;

    private float orthographicSize;
    private float targetOrthoographicSize;

    private void Start() {
        targetOrthoographicSize = orthographicSize = cinemachineVirtualCam.m_Lens.OrthographicSize;
    }

    private void Update() {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void HandleZoom() {
        float zoomAmount = 2f;
        targetOrthoographicSize += -Input.mouseScrollDelta.y * zoomAmount;

        float minOrthographicSize = 10f;
        float maxOrthographicSize = 30;
        targetOrthoographicSize = Mathf.Clamp(targetOrthoographicSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthoographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCam.m_Lens.OrthographicSize = orthographicSize;
    }


}
