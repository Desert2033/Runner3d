using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMovement : MonoBehaviour
{

    private float speed = 5f;

    void Update()
    {

        Vector3 newPos = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position = newPos;

    }
}
