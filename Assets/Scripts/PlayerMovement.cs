using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField] private Vector3 moveVec, gravity;

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpSpeed = 12;

    private int laneNumber = 1;
    private int countLine = 2; // 3

    [SerializeField] private float firstLanePos;
    [SerializeField] private float laneDistance;
    [SerializeField] private float sideSpeed;

    private bool isRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        moveVec = new Vector3(1, 0, 0);
        gravity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (cc.isGrounded)
        {
            gravity = Vector3.zero;

            if (!isRolling)
            {
                if (Input.GetAxis("Vertical") > 0)
                    gravity.y = jumpSpeed;
                else if (Input.GetAxisRaw("Vertical") < 0)
                    StartCoroutine(DoRoll());
            }

        }
        else
        {
            gravity += Physics.gravity * Time.deltaTime * 3;

        }


        //moveVec.x = speed;
        //moveVec += gravity;
        //moveVec *= Time.deltaTime;

        //cc.Move(moveVec);

        CheckInput();
        
        Vector3 newPos = transform.position;
        newPos.z = Mathf.Lerp(newPos.z, firstLanePos + (laneNumber * laneDistance), Time.deltaTime * sideSpeed);

        transform.position = newPos;
        

    }

    private void CheckInput()
    {
        int sign = 0;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            sign = -1;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            sign = 1;
        else
            return;

        laneNumber += sign;
        laneNumber = Mathf.Clamp(laneNumber, 0, countLine);

    }

    IEnumerator DoRoll()
    {
        Debug.Log("rolling");

        isRolling = true;

        yield return new WaitForSeconds(1.5f);

        isRolling = false;

        Debug.Log("no rolling");

    }

}
