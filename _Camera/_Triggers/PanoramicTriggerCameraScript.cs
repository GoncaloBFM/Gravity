using UnityEngine;
using System.Collections;

public class PanoramicTriggerCameraScript : MonoBehaviour {

    public Transform Target;
    public Vector3 SmoothingTime;

    private void OnTriggerEnter() {
        CoreCameraScript.Instance.SetPanoramicCamera(Target, SmoothingTime);
    }

}
