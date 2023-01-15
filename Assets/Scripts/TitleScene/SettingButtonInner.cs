using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonInner : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void ExitSetting()
    {
        GameObject SettingCanvas = GameObject.Find("SettingCanvas(Clone)");
        Destroy(SettingCanvas);
    }
}
