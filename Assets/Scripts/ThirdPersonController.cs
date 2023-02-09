using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public float forwardSpeed = 5f;
    public float sidewaySpeed = 5f;
    public float turnSpeed = 360f;
    public bool rotateWhenStill = true; 

    [SerializeField] private Transform cameraTransform;


    void Start() 
    {

    }


    void Update() 
    {
        Move();
    }


    void Move()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Quaternion direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up);
        if (rotateWhenStill || vInput > 0f || hInput > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, turnSpeed * Time.deltaTime);
        }

        if (vInput != 0f)
        {
            Vector3 forwardMovement = direction * new Vector3(0, 0, 1) * vInput * forwardSpeed * Time.deltaTime;
            transform.position += forwardMovement;
        }

        if (hInput != 0f)
        {
            Quaternion hDirection = Quaternion.Euler(new Vector3(0, 90, 0)) * direction;
            Vector3 sidewayMovement = hDirection * new Vector3(0, 0, 1) * hInput * sidewaySpeed * Time.deltaTime;
            transform.position += sidewayMovement;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }
}
