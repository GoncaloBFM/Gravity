using UnityEngine;
using System.Collections;

public class PlayerSpawnerScript : MonoBehaviour {

    public Transform Player;
    public Vector3 StartingImpulse;

    private Vector3 spawnPosition;


    public static PlayerSpawnerScript Instance {
        get;
        private set;
    }

    public void SpawnPlayer(Color color, float time, int depth) {
        FadeScreenScript.Instance.SetCurrentBackgroundColor(color, depth);
        FadeScreenScript.Instance.FadeOutBackground(time, true, null);

        Player.position = spawnPosition;
        Player.rigidbody.velocity = Vector3.zero;
        Player.rigidbody.AddForce(StartingImpulse, ForceMode.Impulse);
    }

    private void Awake() {
        Instance = this;

        spawnPosition = transform.position;
    }
}
