using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeZoom : MonoBehaviour
{
    float normalCameraAngle = 60f;
    bool zoom;
    void Update()
    {
        if(Input.GetMouseButton(2))
        {
            Debug.Log("»£√‚µ ");
            while(Camera.main.fieldOfView > 30)
            {
                Debug.Log("¿€µø µ ");
                Camera.main.fieldOfView -= 10 * Time.deltaTime;
            }
            
        }
        else
        {
            
        }
    }
}
