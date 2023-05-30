using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float jumpForce = 5f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private bool isJumping = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Ruch postaci
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;
        characterController.SimpleMove(movement);

        // Skok
        if (characterController.isGrounded)
        {
            isJumping = false;

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }
        }

        if (isJumping)
        {
            characterController.Move(Vector3.up * jumpForce * Time.deltaTime);
        }

        // Obrót kamery
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}