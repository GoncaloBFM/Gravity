using UnityEngine;
using System.Collections;

public class CoreCameraScript : MonoBehaviour {

    private AxisCameraScript axisCameraScript;
    private PanoramicCameraScript panoramicCameraScript; 
    private MonoBehaviour _currentCamera;

    private MonoBehaviour currentCamera {
        get {
            return _currentCamera;
        }
        set {
            _currentCamera.enabled = false;
            _currentCamera = value;
            _currentCamera.enabled = true;
        }
    }

    public static CoreCameraScript Instance {
        get;
        private set;
    }

    public void SetAxisCamera(Transform target, AxisEnum axis, Transform firstConstraint, Transform secondConstraint, Transform fixedPoint, Transform zPosition, Vector3 smoothingTime) {
        axisCameraScript.SetValues(target, axis, firstConstraint, secondConstraint, fixedPoint, zPosition, smoothingTime);
        currentCamera = axisCameraScript;
    }

    public void SetPanoramicCamera(Transform target, Vector3 smoothingTime) {
        panoramicCameraScript.SetValues(target, smoothingTime);
        currentCamera = panoramicCameraScript;
    }

    private void Awake() {
        Instance = this;

        axisCameraScript = GetComponent<AxisCameraScript>();
        panoramicCameraScript = GetComponent<PanoramicCameraScript>();

        InitializeToDefault();
    }

    private void InitializeToDefault() {
        _currentCamera = axisCameraScript;
    }

}
