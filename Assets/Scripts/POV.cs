using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POV : MonoBehaviour
{

    [Range(0.01f, 5f)]
    public float step = 10f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private const float MAX_DISTANCE = 495;

    void Update () {

        step += Input.mouseScrollDelta.y;
        step = step >= 5 ? 5 : step;
        step = step <= 0.01f ? 0.01f : step;

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.W)) this.transform.position += transform.forward * step;
        if (Input.GetKey(KeyCode.S)) this.transform.position += -transform.forward * step;
        if (Input.GetKey(KeyCode.A)) this.transform.position += -transform.right * step;
        if (Input.GetKey(KeyCode.D)) this.transform.position += transform.right * step;
        if (Input.GetKey(KeyCode.Z)) this.transform.position += transform.up * step;
        if (Input.GetKey(KeyCode.C)) this.transform.position += -transform.up * step;

        Vector3 position = transform.position;

        position.x = position.x > MAX_DISTANCE ? MAX_DISTANCE : position.x;
        position.x = position.x < -MAX_DISTANCE ? -MAX_DISTANCE : position.x;
        position.y = position.y > MAX_DISTANCE ? MAX_DISTANCE : position.y;
        position.y = position.y < -MAX_DISTANCE ? -MAX_DISTANCE : position.y;
        position.z = position.z > MAX_DISTANCE ? MAX_DISTANCE : position.z;
        position.z = position.z < -MAX_DISTANCE ? -MAX_DISTANCE : position.z;

        transform.position = position;
    }
}
