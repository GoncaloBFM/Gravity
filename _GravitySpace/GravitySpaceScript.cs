using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravitySpaceScript : MonoBehaviour {

    public Vector3 Gravity;
    public int Filter;

    public bool IsDefaultFilter {
        get;
        private set;
    }

    private void Start() {
        IsDefaultFilter = GameInformationScript.Instance.DefaultGravityFilter == Filter;
    }

}