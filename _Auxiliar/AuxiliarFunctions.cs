using UnityEngine;
using System.Collections;

public class AuxiliarFunctions {

    public static Vector3 IndividualSmoothDamp(Vector3 current, Vector3 target, Vector3 smoothTime) {
        Vector3 velocity = Vector3.zero;

        return new Vector3(Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime.x),
                           Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime.y),
                           Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime.z));

    }

}
