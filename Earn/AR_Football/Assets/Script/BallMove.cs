using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Vector2 startPos, endPos, direction, mpos;

    float touchTimeStart, touchTimeFinish, timeInterval, timeM;

    [SerializeField]
    float throwForceInXandY = 1f;
    [SerializeField]
    float throwForceInZ = 100f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        touchTimeStart = Time.time;
        startPos = Input.mousePosition;
        startPos = Camera.main.ScreenToWorldPoint(startPos);
    }

    void OnMouseUp()
    {
        touchTimeFinish = Time.time;
        timeInterval = touchTimeFinish - touchTimeStart;
        endPos = Input.mousePosition;
        direction = startPos - endPos;
        rb.isKinematic = false;
        rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY * 1f, throwForceInZ / timeInterval * 2f);
        InvokeRepeating("ReturnBall", 5, 20);
    }
    void ReturnBall()
    {
        rb.isKinematic = true;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;

    }
}
