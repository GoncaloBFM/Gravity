using UnityEngine;
using System.Collections;

public class MovingBlockScript : MonoBehaviour {

    public float MovingTime;
    public float WaitingTime;
    public Vector3 SecondPosition;
    

    private Transform myTransform;
    private Vector3 firstPosition;
    private bool isMoving;
    private bool isDone;


    private void Awake() {
        myTransform = transform;
        firstPosition = myTransform.position;
        isMoving = false;
        isDone = false;
    }

    private void Update() {
        if (!isMoving) {
            if (isDone) {
                StartCoroutine(MoveOverTime(firstPosition, MovingTime));
            } else {
                StartCoroutine(MoveOverTime(SecondPosition, MovingTime));
            }
        }
    }

    private IEnumerator MoveOverTime(Vector3 targetPosition, float time) {
        float p1 = 0.0f;
        float rate = 1.0f / time;
        Vector3 oldPosition = myTransform.position;
        isMoving = true;
        while (p1 < 1.0f) {
            myTransform.position = Vector3.Slerp(oldPosition, targetPosition, p1);
            p1 += Time.deltaTime * rate;
            yield return null;
        }
        StartCoroutine(Wait(WaitingTime));
    }

    private IEnumerator Wait(float waitingTime) {
        yield return new WaitForSeconds(waitingTime);
        isMoving = false;
        isDone = !isDone;
    }

}
