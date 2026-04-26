using System;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public PlayerObject player;
    public Camera playerCamera;

    [Header("FMOD Settings")]
    public EventReference footstepEvent;
    public EventReference jumpEvent;
    public EventReference landEvent;
    public string surfaceParameter = "Terrain";

    public float baseStepSpeed = 0.5f;
    public float runStepSpeed = 0.3f;
    private float footstepTimer;

    private bool wasGrounded;
    private Terrain terrain;
    private TerrainData terrainData;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        terrain = Terrain.activeTerrain;
        if (terrain != null) terrainData = terrain.terrainData;

        wasGrounded = characterController.isGrounded;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = canMove ? (isRunning ? player.runSpeed : player.walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? player.runSpeed : player.walkSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButtonDown("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = player.jumpPower;
            PlayActionSound(jumpEvent);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!wasGrounded && characterController.isGrounded)
        {
            PlayActionSound(landEvent);
        }
        wasGrounded = characterController.isGrounded;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= player.gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * player.lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -player.lookXLimit, player.lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * player.lookSpeed, 0);
        }

        if (characterController.isGrounded && (Mathf.Abs(curSpeedX) > 0.1f || Mathf.Abs(curSpeedY) > 0.1f))
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0)
            {
                PlayFootstep();
                footstepTimer = isRunning ? runStepSpeed : baseStepSpeed;
            }
        }
    }

    private void PlayFootstep()
    {
        float surfaceIndex = 3;

        RuntimeManager.StudioSystem.setParameterByName(surfaceParameter, surfaceIndex);
        FMOD.Studio.EventInstance footstep = RuntimeManager.CreateInstance(footstepEvent);
        footstep.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        footstep.start();
        footstep.release();
    }

    private void PlayActionSound(EventReference actionEvent)
    {
        if (actionEvent.IsNull) return;

        float surfaceIndex = 3;
        RuntimeManager.StudioSystem.setParameterByName(surfaceParameter, surfaceIndex);

        FMOD.Studio.EventInstance instance = RuntimeManager.CreateInstance(actionEvent);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        instance.start();
        instance.release();
    }
}