using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    [SerializeField] CharacterController controller;

    Vector3 currentDir = Vector3.zero;
    Vector3 currentDirVelocity = Vector3.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    bool stopMove = false;

    void Start()
    {
        
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void lockplayer(bool islocked)
    {
        if (!islocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            stopMove = false;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            stopMove = true;
            
        }
    }
    void Update()
    {
        if (!stopMove)
        {
            UpdateMouseLook();
        }
        UpdateMovement();

    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed = walkSpeed * 2;
            
        }
        if (Input.GetKeyDown(KeyCode.Return))   
        {
            Application.OpenURL("https://www.youtube.com/watch?v=nPAj2y2buHU");
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = walkSpeed*(0.5f);
        }
        float dy=0;
        if (Input.GetKey(KeyCode.Space))
        {
            dy = walkSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            dy -= walkSpeed * Time.deltaTime;
        }
            Vector3 targetDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), dy);
        targetDir.Normalize();

        currentDir = Vector3.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x+transform.up*currentDir.z) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }



   
 }
