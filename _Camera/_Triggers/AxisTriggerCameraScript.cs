using UnityEngine;
using System.Collections;

public class AxisTriggerCameraScript : MonoBehaviour {

    public Transform Target;
    public AxisEnum Axis;
    public Transform FirstConstraint;
    public Transform SecondConstraint;
    public Transform FixedPoint;
    public Transform ZPosition;
    public Vector3 SmoothingTime;

    private void OnTriggerEnter() {
        CoreCameraScript.Instance.SetAxisCamera(Target, Axis, FirstConstraint, SecondConstraint, FixedPoint, ZPosition, SmoothingTime);
    }

}
