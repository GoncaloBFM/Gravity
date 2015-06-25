using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadScript : MonoBehaviour {

    private static DontDestroyOnLoadScript instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
