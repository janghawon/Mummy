using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonInner : MonoBehaviour
{
    GameObject SettingCanvas;
    private void Awake()
    {
        SettingCanvas = GameObject.Find("SettingCanvas");
    }
    public void ExitSetting()
    {
        SettingCanvas.SetActive(false);
    }
}
