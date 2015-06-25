using UnityEngine;
using System.Collections;

public class ButtonBlockScript : MonoBehaviour, ActionButtonInterface {

    public float MovingTime;
    public Vector3 SecondPosition;

    private Transform myTransform;
    private Vector3 firstPosition;

    public void On() {
        StopAllCoroutines();
        StartCoroutine(MoveOverTime(SecondPosition, MovingTime));
    }

    public void Off() {
        StopAllCoroutines();
        StartCoroutine(MoveOverTime(firstPosition, MovingTime));
    }

    private void Awake() {
        myTransform = transform;
        firstPosition = myTransform.position;
    }

    private IEnumerator MoveOverTime(Vector3 targetPosition, float time) {
        float p1 = 0.0f;
        float rate = 1.0f / time;
        Vector3 oldPosition = myTransform.position;
        while (p1 < 1.0f) {
            myTransform.position = Vector3.Slerp(oldPosition, targetPosition, p1);
            p1 += Time.deltaTime * rate;
            yield return null;
        }
    }
}
