using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isometric1Controller : MonoBehaviour
{

    // [SerializeField] private Rigidbody _rb;
    // [SerializeField] private float _speed = 5;
    // private Vector3 _input;

    // void Update() {
    //     GatherInput();
    // }

    // void FixedUpdate() {
    //     Move();
    // }

    // void GatherInput() {
    //     _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    // }

    // void Move() {
    //     _rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    // }

    public float speed = 5f;
    Vector3 forward;
    Vector3 right;

    void Start() 
    {
        forward = Camera.main.transform.forward; // forward is the direction of the camera
        forward.y = 0;
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
