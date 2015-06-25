using UnityEngine;
using System.Collections;

public abstract class GenericGravityWell : MonoBehaviour {

    public float Force;
    public float MaxDistance;
    public bool InvertPull;

    protected Transform myTransform;
    protected int filter;

    private void Awake() {
        myTransform = transform;
    }

}
