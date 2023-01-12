using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 0;
    [SerializeField] float zoomMax = 0;
    [SerializeField] float zoomMin = 0;

    void CameraZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        if (transform.position.y <= zoomMax && t_zoomDirection > 0)
        {
            Debug.Log(2);
            return;
        }
        else
        {
            Debug.Log(2.1);
        }

        if (transform.position.y >= zoomMin && t_zoomDirection < 0)
        {
            Debug.Log(3);
            return;
        }
        else
        {
            Debug.Log(3.1);
        }
            

        transform.position += transform.forward * t_zoomDirection * zoomSpeed;
    }

    private void Update()
    {
        CameraZoom();
    }
}
