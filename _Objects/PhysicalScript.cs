using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicalScript : MonoBehaviour {

    public int GravityFilter;

    private Rigidbody myRigidbody;
    private Transform myTransform;

    private LinkedList<GravitySpaceScript> _gravitySpaces;
    private bool useSettingsGravity;
    private string gravitySpaceTag;

    private LinkedList<GravitySpaceScript> gravitySpaces = new LinkedList<GravitySpaceScript>();

    public void ForceToPoint(Vector3 point, float maxForce, float maxDistance, bool inverseDirection, ForceMode mode) {
        Vector3 myPosition = myTransform.position;
        float distance = Vector3.Distance(myPosition, point);
        if (distance <= maxDistance) {
            Vector3 direction = (point - myPosition);
            if (inverseDirection) {
                direction *= -1;
            }
            myRigidbody.AddForce(direction.normalized * (1f - distance / maxDistance) * maxForce, mode);
        }
    }

    public void PushInDirection(Vector3 force) {
        myRigidbody.AddForce(force);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == gravitySpaceTag) {
            gravitySpaces.AddLast(collider.GetComponent<GravitySpaceScript>());
            SelectGravitySource();
        }
    }


    public void OnTriggerExit(Collider collider) {
        if (collider.tag == gravitySpaceTag) {
            gravitySpaces.Remove(collider.GetComponent<GravitySpaceScript>());
            SelectGravitySource();
        }
    }

    private void FixedUpdate() {
        if (useSettingsGravity) {
            PushInDirection(GameSettingsScript.Instance.DefaultSceneGravity);
        } else {
            foreach (GravitySpaceScript gravitySpace in gravitySpaces) {
                PushInDirection(gravitySpace.Gravity);
            }
        }
    }

    private void SelectGravitySource() {
        useSettingsGravity = (gravitySpaces.Count == 0);
    }

    private void Awake() {
        myTransform = transform;
        myRigidbody = rigidbody;

        SelectGravitySource();
    }

    private void Start() {
        gravitySpaceTag = GameInformationScript.Instance.GravitySpaceTag;

        ReferencesScript.Instance.PhysicalScripts.AddLast(this);
    }

    private void OnDestroy() {
        ReferencesScript.Instance.PhysicalScripts.Remove(this);
    }
}
