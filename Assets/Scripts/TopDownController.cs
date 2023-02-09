using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// copied and altered from Isometric1Controller Script (so kinda jank)

public class TopDownController : MonoBehaviour
{

    public float speed = 5f;
    Vector3 forward;
    Vector3 right;

    void Start() 
    {
        forward = new Vector3(0, 0, -1); // changed from Isometric1Controller Script
        // forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update() 
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
