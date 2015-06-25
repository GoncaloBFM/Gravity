using UnityEngine;
using System.Collections;

public class ImpulseGravityWellScript : GenericGravityWell {

    private void FixedUpdate() {
        foreach (PhysicalScript physicalScript in ReferencesScript.Instance.PhysicalScripts) {
            if (physicalScript.GravityFilter == filter) {
                physicalScript.ForceToPoint(myTransform.position, Force, MaxDistance, InvertPull, ForceMode.Impulse);
            }
        }
        enabled = false;
    }
}
