using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseAim : MonoBehaviour
{
    //public Image aimImage;
    public RectTransform cursurTransform;
    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        cursurTransform.position = mousePos;
        
        if(Input.GetMouseButtonDown(0))
        {
            audio.Play();
        }

    }
}
