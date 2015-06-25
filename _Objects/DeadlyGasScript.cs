using UnityEngine;
using System.Collections;

public class DeadlyGasScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {

        if (collision.collider.name == GameInformationScript.Instance.PlayerTag) {
            GameStateScript.Instance.RestartLevel();
        }
    }

}
