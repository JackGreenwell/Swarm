using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public Transform CameraFP;

    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 2f;
    private Vector3 moveDirection = new Vector3(0, 0, 0);

    float rotateX, rotateY;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60f;
    public float mouseSens = 2f;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Movement();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    //This function takes input to allow the player to move and jump
    void Movement()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }
    
    //This function takes mouse input to allow the player to look around
    void Rotate()
    {

        rotateX = Input.GetAxis("Mouse X") * mouseSens;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSens;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);
        transform.Rotate(0f, rotateX, 0f);

        CameraFP.transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
