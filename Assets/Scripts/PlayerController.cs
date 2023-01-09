using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RotationMouse rotationMouse;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotationMouse = GetComponent<RotationMouse>();
    }
    private void Update()
    {
        UpdateRotate();
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationMouse.UpdateRotate(mouseX, mouseY);
    }
}
