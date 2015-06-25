using UnityEngine;
using System.Collections;

public class EndLevelTriggerScript : MonoBehaviour {
    private void OnTriggerEnter(Collider collider) {
        if (collider.name == GameInformationScript.Instance.PlayerTag) {
            GameStateScript.Instance.EndLevelTransition();
        }
    }

}
 