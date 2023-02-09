using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
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
        forward = new Vector3(0, 0, 1); // forward is the direction of the camera
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
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 forwardMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 direction = Vector3.Normalize(forwardMovement + rightMovement);

        transform.forward = direction; //rotate to face in direction of movement
        transform.position += rightMovement;
        transform.position += forwardMovement;
    }
}
