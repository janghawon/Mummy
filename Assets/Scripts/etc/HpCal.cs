using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpCal : MonoBehaviour
{
    GameManager gameManager;
    PlayerHP playerHP;
    bool first;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerHP = FindObjectOfType<PlayerHP>();
        first = true;
    }
    void Update()
    {
        if(playerHP.playerCurrentHP <= 0 && first)
        {
            first = false;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        gameManager.SceneProduction("next");
        yield return new WaitForSeconds(1.2f);
        gameManager.SceneLoad("GameOver");
    }
}
