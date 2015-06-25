using UnityEngine;
using System.Collections;

public class AxisCameraScript : MonoBehaviour {

    private AxisEnum axis;
    private Transform myTransform;
    private Transform target;
    //left or down
    private float firstConstraint;
    //right or up
    private float secondConstraint;
    private float fixedPoint;
    private float zPosition;
    private Vector3 smoothingTime;

    public void SetValues(Transform target, AxisEnum axis, Transform firstConstraint, Transform secondConstraint, Transform FixedPoint, Transform zPosition, Vector3 smoothingTime) {
        this.target = target;
        this.axis = axis;
        this.zPosition = zPosition.position.z;
        this.smoothingTime = smoothingTime;

        switch (axis) {
            case AxisEnum.Horizontal:
                this.firstConstraint = firstConstraint.position.x;
                this.secondConstraint = secondConstraint.position.x;
                this.fixedPoint = FixedPoint.position.y;
                break;
            case AxisEnum.Vertical:
                this.firstConstraint = firstConstraint.position.y;
                this.secondConstraint = secondConstraint.position.y;
                this.fixedPoint = FixedPoint.position.x;
                break;
        }
    }

    private void Awake() {
        myTransform = transform;
    }

    private void Update() {
        Vector3 newPosition = target.position;

        switch (axis) {
            case AxisEnum.Horizontal:
                if (target.position.x < firstConstraint) {
                    newPosition.x = firstConstraint;
                } else if (target.position.x > secondConstraint) {
                    newPosition.x = secondConstraint;
                }
                newPosition.y = fixedPoint;
                break;
            case AxisEnum.Vertical:
                if (target.position.y < firstConstraint) {
                    newPosition.y = firstConstraint;
                } else if (target.position.y > secondConstraint) {
                    newPosition.y = secondConstraint;
                }
                newPosition.x = fixedPoint;
                break;
        }

        newPosition.z = zPosition;

        
        myTransform.position = AuxiliarFunctions.IndividualSmoothDamp(myTransform.position, newPosition, smoothingTime);
    }

}
