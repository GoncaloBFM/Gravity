using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReferencesScript : MonoBehaviour {

    public LinkedList<PhysicalScript> PhysicalScripts = new LinkedList<PhysicalScript>();

    public static ReferencesScript Instance {
        get;
        private set;
    }

    private void Awake() {
        Instance = this;
    }
}
