using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Camera camera;

    private void Awake()
    {
        //camera = GameObject.Find("Player").transform.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
