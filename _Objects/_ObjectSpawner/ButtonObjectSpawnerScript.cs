using UnityEngine;
using System.Collections;

public class ButtonObjectSpawnerScript : GenericObjectSpawner, ActionButtonInterface {

    public void On() {
        Spawn();
    }

    public void Off() {

    }

}
