using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector2 inputMovement;
    private Vector3 primaryAngle;
    private Vector3 angle;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float rotateSpeed = 1f;


    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        SetupCamera();
    }

    void Update()
    {
        RotateCamera();
    }

    // Input System
    public void OnLook(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    private void SetupCamera()
    {
        primaryAngle = Vector3.zero;

        angle = primaryAngle;
        mainCamera.gameObject.transform.localEulerAngles = angle;
    }

    // Update
    private void RotateCamera()
    {
        angle.x -= inputMovement.y * rotateSpeed;
        angle.y += inputMovement.x * rotateSpeed;

        angle.x = Mathf.Clamp(angle.x, -25f, 25f);
        angle.y = Mathf.Clamp(angle.y, -45f, 45f);

        mainCamera.gameObject.transform.localEulerAngles = angle;
    }

}
