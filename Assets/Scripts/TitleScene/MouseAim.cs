using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseAim : MonoBehaviour
{
    
    AudioSource audio;
    RectTransform mouse;
    public bool canSound;
    private void Awake()
    {
        audio = GetComponentInChildren<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canSound = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0) && canSound)
        {
            audio.Play();
        }

        //mouse.SetAsLastSibling();
    }
}
