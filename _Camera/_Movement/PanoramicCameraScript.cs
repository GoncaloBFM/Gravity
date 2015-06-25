using UnityEngine;
using System.Collections;

public class PanoramicCameraScript : MonoBehaviour {

    private Transform myTransform;
    private Vector3 target;
    private Vector3 smoothingTime;

    public void SetValues(Transform target, Vector3 smoothingTime) {
        this.target = target.position;
        this.smoothingTime = smoothingTime;
    }

    private void Awake() {
        myTransform = transform;
    }

    private void Update() {
        myTransform.position = AuxiliarFunctions.IndividualSmoothDamp(myTransform.position, target, smoothingTime);
    }
}
