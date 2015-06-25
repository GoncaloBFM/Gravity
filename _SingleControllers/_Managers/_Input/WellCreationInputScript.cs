using UnityEngine;
using System.Collections;
using System;

public class WellCreationInputScript : MonoBehaviour {

    public Transform NormalPullGravityWellPrefab;
    public Transform NormalPushGravityWellPrefab;

    public Transform ImpulsePullGravityWellPrefab;
    public Transform ImpulsePushGravityWellPrefab;

    public float ZOffset;

    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    private bool isPullActive;
    private bool isPushActive;
    private bool isStickyActive;
    private Transform gravityWell;
    private Transform stickyGravityWell;
    private Transform mainCamera;


    private void Awake() {
        isPullActive = false;
        isPushActive = false;
        gravityWell = null;

        isStickyActive = false;
        stickyGravityWell = null;

        mainCamera = Camera.main.transform;
    }

    private void Update() {
        if (!isPushActive) {
            if (Input.GetMouseButtonDown(LeftMouseButton)) {
                if (Input.GetKey(KeyCode.LeftControl)) {
                    Debug.Log("Impulse Pull");
                    Instantiate(ImpulsePullGravityWellPrefab, GetMousePosition(), Quaternion.identity);
                } else {
                    Debug.Log("Normal Pull");
                    gravityWell = Instantiate(NormalPullGravityWellPrefab, GetMousePosition(), Quaternion.identity) as Transform;
                    isPullActive = true;
                }
            } else if (isPullActive && Input.GetMouseButton(LeftMouseButton)) {
                gravityWell.position = GetMousePosition();
            } else if (isPullActive) {
                Destroy(gravityWell.gameObject);
                isPullActive = false;
            }
        }

        if (!isPullActive) {
            if (Input.GetMouseButtonDown(RightMouseButton)) {
                if (Input.GetKey(KeyCode.LeftControl)) {
                    Debug.Log("Impulse Push");
                    Instantiate(ImpulsePushGravityWellPrefab, GetMousePosition(), Quaternion.identity);
                } else {
                    Debug.Log("Normal Push");
                    gravityWell = Instantiate(NormalPushGravityWellPrefab, GetMousePosition(), Quaternion.identity) as Transform;
                    isPushActive = true;
                }
            } else if (Input.GetMouseButton(RightMouseButton) && isPushActive) {
                gravityWell.position = GetMousePosition();
            } else if (isPushActive) {
                Destroy(gravityWell.gameObject);
                isPushActive = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (!isStickyActive && (isPushActive || isPullActive)) {
                Debug.Log("Sicky On");
                stickyGravityWell = gravityWell;
                isPullActive = false;
                isPushActive = false;
                gravityWell = null;
                isStickyActive = true;
            }
        } else if (isStickyActive) {
            Destroy(stickyGravityWell.gameObject);
            isStickyActive = false;
        }
    }

    private Vector3 GetMousePosition() {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.position.z - ZOffset));
    }

}
