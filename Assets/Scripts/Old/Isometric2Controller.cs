using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isometric2Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnspeed = 360;
    private Vector3 _input;

    void Update() {
        GatherInput();
        Look();
    }

    void FixedUpdate() {
        Move();
    }

    void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look() {
        if (_input != Vector3.zero) 
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime);

        }

    }

    void Move() {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
}
