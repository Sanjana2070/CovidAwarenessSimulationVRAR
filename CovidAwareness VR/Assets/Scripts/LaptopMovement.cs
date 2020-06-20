using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopMovement : MonoBehaviour
{
    private CharacterController characterController = null;


    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;

    //Movement in laptop
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseX;
        yRotation -= mouseY;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.right * -mouseY);



        //For movement in laptop
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);
    }
}
