using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public PlayerObject player;
    public Camera playerCamera;

    //public StepsALL Steps;

    bool isRunning = false;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;



    private void Awake()
    {
        player.runSpeed = 6f;
        player.walkSpeed = 3f;
    }
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.TimeSinceStep += Time.deltaTime;

    }

    void Update()
    {
        AudioSource walkSound = GetComponent<AudioSource>();
        //walkSound.clip = walk;
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? player.runSpeed : player.walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? player.runSpeed : player.walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = player.jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= player.gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * player.lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -player.lookXLimit, player.lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * player.lookSpeed, 0);
        }

        #endregion


        /* if (characterController.isGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
         {
             if (player.StepCoolDowntime - player.TimeSinceStep < 0.2d)
             {
                 Steps.PlayFootSteps();
                 player.TimeSinceStep = 0;
             }
             else if (isRunning && player.StepCoolDowntime - player.TimeSinceStep < 0.5d)
             {
                 Steps.PlayFootSteps();
                 player.TimeSinceStep = 0;
             }

         }*/
       // player.TimeSinceStep += Time.deltaTime;
        //tilt camera

        /*#region Crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {

            characterController.height = 0.5f;
            characterController.center = new Vector3(0, 0.2f, 0);
        }
        else
        {

            characterController.height = 2f;
            characterController.center = Vector3.zero;
        }
        
        #endregion*/

    }
    public Boolean isrunning()
    {
        return isRunning;
    }

}

