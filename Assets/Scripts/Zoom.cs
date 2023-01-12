using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] float zoomSpeed = 0;
    [SerializeField] float zoomMax = 4;
    [SerializeField] float zoomMin = 60;
    [SerializeField] private float cameraViewShame;
    [SerializeField] private Image scopeScreen;
    [SerializeField] private Image aim;
    float fadeCount;
    public bool tryScoping;

    
    private void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        scopeScreen = GameObject.Find("ScopeScreen").GetComponent<Image>();
        aim = GameObject.Find("Aim").GetComponent<Image>();
    }
    private void Start()
    {
        camera.fieldOfView = 60;
        zoomMax = 10;
        zoomMin = 60;
        cameraViewShame = camera.fieldOfView;

        scopeScreen.enabled = true;
        scopeScreen.color = new Color(1, 1, 1, 0);
        scopeScreen.gameObject.SetActive(false);
    }

    IEnumerator CameraZoom()
    {
        while(camera.fieldOfView > zoomMax)
        {
            camera.fieldOfView -= 1;
            yield return new WaitForSeconds(0.1f);
        }
        while(fadeCount < 1)
        {
            fadeCount += 1;
            scopeScreen.color = new Color(1, 1, 1, fadeCount);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator CameraZoomOut()
    {
        while(camera.fieldOfView < zoomMin)
        {
            camera.fieldOfView += 1;
            yield return new WaitForSeconds(0.1f);
        }
        while (fadeCount > 0)
        {
            fadeCount -= 1;
            scopeScreen.color = new Color(1, 1, 1, fadeCount);
            yield return new WaitForSeconds(0.05f);
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
            scopeScreen.gameObject.SetActive(true);
            aim.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(CameraZoomOut());
            scopeScreen.gameObject.SetActive(false);
            aim.gameObject.SetActive(true);
        }
    }
    
}
