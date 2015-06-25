using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GenericObjectSpawner : MonoBehaviour {

    public Transform Object;
    public float ObjectLifetime; //0 == infinite
    public int MaxObjectNumber;  //0 == infinite

    private Vector3 spawnPosition;
    private LinkedList<GameObject> objectsList = new LinkedList<GameObject>();

    private void Awake() {
        spawnPosition = transform.position;
    }

    protected void Spawn() {
        GameObject instantiatedObject = (Instantiate(Object, spawnPosition, Quaternion.identity) as Transform).gameObject;
        objectsList.AddLast(instantiatedObject);

        if (ObjectLifetime != 0) {
            DestroyObjectAfterTime(instantiatedObject, ObjectLifetime);
        }
        if ((MaxObjectNumber > 0) && (objectsList.Count > MaxObjectNumber)) {
            SecureDestroy(objectsList.First.Value);
        }
    }

    private IEnumerator DestroyObjectAfterTime(GameObject objectToDestroy, float timer) {
        yield return new WaitForSeconds(timer);
        SecureDestroy(objectToDestroy);
    }

    private void SecureDestroy(GameObject objectToDestroy) {
        if (objectToDestroy != null) {
            Destroy(objectToDestroy);
            objectsList.RemoveFirst();
        }
    }
}
