using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOptionManager : MonoBehaviour
{
    GameManager gm;
    public bool canOpenPannel;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        canOpenPannel = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canOpenPannel)
        {
            gm.SceneProduction("option");
            canOpenPannel = false;
        }
    }
}
