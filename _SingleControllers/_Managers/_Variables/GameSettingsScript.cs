using UnityEngine;
using System.Collections;

public class GameSettingsScript : MonoBehaviour {

    public Vector3 DefaultSceneGravity;

    public static GameSettingsScript Instance {
        get;
        private set;
    }

    private void Awake() {
        Instance = this;
    }
}
