using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    Vector3 startDistance, moveVec;

    // Start is called before the first frame update
    void Start()
    {
        startDistance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVec = target.position + startDistance;

        moveVec.z = 0;
        moveVec.y = startDistance.y;
        transform.position = moveVec;
    }
}
