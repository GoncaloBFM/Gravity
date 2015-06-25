using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NormalGravityWellScript : GenericGravityWell {

    private LinkedList<PhysicalScript> physicalScripts;

    private void FixedUpdate() {

        foreach (PhysicalScript physicalScript in physicalScripts) {
            if (physicalScript.GravityFilter == filter) {
                physicalScript.ForceToPoint(myTransform.position, Force, MaxDistance, InvertPull, ForceMode.Force);
            }
        }
    }

    public void SetValues(int filter, Material wellMaterial) {
        this.filter = filter;
        myTransform.renderer.material = wellMaterial;
    }

    private void Start() {
        physicalScripts = ReferencesScript.Instance.PhysicalScripts;

        if (InvertPull) {
            filter = WellFilterInputScript.Instance.CurrentPushFilterValue;
        } else {
            filter = WellFilterInputScript.Instance.CurrentPullFilterValue;
        }
    }
}