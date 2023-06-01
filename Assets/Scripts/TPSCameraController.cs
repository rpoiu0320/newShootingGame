using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float lookDistance;
    [SerializeField] Transform aimTarget;
    //[SerializeField] Vector3 aim;

    private Vector2 lookDelta;
    private float xRotation;
    private float yRotation;

    private void Update()
    {
        Rotate();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Rotate()
    {
        Vector3 lookPoint = Camera.main.transform.position + Camera.main.transform.forward * lookDistance;
        aimTarget.position = lookPoint;
        // aim = lookPoint;
        lookPoint.y = transform.position.y;
        transform.LookAt(lookPoint);
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Look()
    {
        yRotation += lookDelta.x * mouseSensitivity * Time.deltaTime;
        xRotation -= lookDelta.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraRoot.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void OnLook(InputValue value)
    {
        lookDelta = value.Get<Vector2>();
    }
}
