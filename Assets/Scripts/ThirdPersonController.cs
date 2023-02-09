using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    public float forwardSpeed = 5f;
    public float sidewaysSpeed = 5f;
    public float turnSpeed = 360f;
    public bool rotateWhenStill = true; 

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Animator anim;


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
        bool isMovingForward = Mathf.Abs(vInput) >= 0.02;
        bool isMovingSideways = Mathf.Abs(hInput) >= 0.02;

        Quaternion direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up);
        if (rotateWhenStill || isMovingForward || isMovingSideways)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, turnSpeed * Time.deltaTime);
        }

        if (isMovingForward)
        {
            Vector3 forwardMovement = direction * new Vector3(0, 0, 1) * vInput * forwardSpeed * Time.deltaTime;
            transform.position += forwardMovement;
            // anim.SetFloat("walkSpeed", Mathf.Abs(vInput)); // switch vInput for vInput * forwardSpeed if you want forward speed to affect speed of animation
        }

        if (isMovingSideways)
        {
            Quaternion hDirection = Quaternion.Euler(new Vector3(0, 90, 0)) * direction;
            Vector3 sidewaysMovement = hDirection * new Vector3(0, 0, 1) * hInput * sidewaysSpeed * Time.deltaTime;
            transform.position += sidewaysMovement;
            // anim.SetFloat("walkSpeed", Mathf.Abs(hInput));
        }

        if (isMovingForward || isMovingSideways)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
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
