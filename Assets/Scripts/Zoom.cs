using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] float zoomSpeed = 0;
    [SerializeField] float zoomMax = 4;
    [SerializeField] float zoomMin = 60;
    [SerializeField] private float cameraViewShame;
    private void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Start()
    {
        camera.fieldOfView = 60;
        zoomMax = 10;
        zoomMin = 60;
        cameraViewShame = camera.fieldOfView;
    }

    IEnumerator CameraZoom()
    {
        while(camera.fieldOfView > zoomMax)
        {

            camera.fieldOfView -= 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator CameraZoomOut()
    {
        while(camera.fieldOfView < zoomMin)
        {
            camera.fieldOfView += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(cameraViewShame);
        }
        
        if (Input.GetMouseButton(1))
        {
            
            StartCoroutine(CameraZoom());
        }
        else
        {
            StartCoroutine(CameraZoomOut());
            
        }
    }
    
}
