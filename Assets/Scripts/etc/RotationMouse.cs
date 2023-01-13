using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMouse : MonoBehaviour
{
    [SerializeField] private float camXSpeed = 5;
    [SerializeField] private float camYSpeed = 3;

    private float limitMinX = -80f;
    private float limitMaxX = 50f;
    private float eulerAngX;
    private float eulerAngY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngY += mouseX * camYSpeed;
        eulerAngX -= mouseY * camXSpeed;

        eulerAngX = ClampAngle(eulerAngX, limitMinX, limitMaxX);
        transform.rotation = Quaternion.Euler(eulerAngX, eulerAngY, 0);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360)
        {
            angle += 360;
        }
        if(angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
