using UnityEngine;
using System.Collections;

public class DisableRendererScript : MonoBehaviour {

	private void Awake() {
        GetComponent<MeshRenderer>().enabled = false;	
	}
	
}
