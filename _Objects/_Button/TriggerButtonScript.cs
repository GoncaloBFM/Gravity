using UnityEngine;
using System.Collections.Generic;

public class TriggerButtonScript : MonoBehaviour {

    public Material OffMaterial;
    public Material OnMaterial;
    public List<Transform> ActionObjects = new List<Transform>();
    
    private LinkedList<ActionButtonInterface> actions = new LinkedList<ActionButtonInterface>();
    private Transform myTransform;

    private void Awake() {
        foreach (Transform actionObject in ActionObjects) {
            actions.AddFirst(actionObject.GetComponent(typeof(ActionButtonInterface)) as ActionButtonInterface);
        }
        myTransform = transform;
        myTransform.renderer.material = OffMaterial;
    }

    private void OnCollisionEnter(Collision collision) {
        foreach (ActionButtonInterface action in actions) {
            action.On();
        }
        myTransform.renderer.material = OnMaterial;
    }

    private void OnCollisionExit(Collision collision) {
        foreach (ActionButtonInterface action in actions) {
            action.Off();
        }
        myTransform.renderer.material = OffMaterial;
    }

}
