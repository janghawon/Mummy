using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonClickEvent : MonoBehaviour
{
    GameManager gameManager;
    GameObject settingCanvas;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        settingCanvas = GameObject.Find("SettingCanvas");
    }
    public void GameStartButton()
    {
        gameManager.SceneProduction("next");
        StartCoroutine(GameStart());
    }
    public void OptionButton()
    {
        gameManager.SceneProduction("option");
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1.2f);
        gameManager.SceneLoad(gameManager.sceneList[1]);
    }
}
