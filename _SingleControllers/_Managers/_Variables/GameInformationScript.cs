using UnityEngine;
using System.Collections;

public class GameInformationScript : MonoBehaviour {

    public string GravityWellTag;
    public string GravitySpaceTag;
    public string PlayerTag;

    public int DefaultGravityFilter;
   
    public static GameInformationScript Instance {
        get;
        private set;
    }

    private void Awake() {
        Instance = this;
    }

}
