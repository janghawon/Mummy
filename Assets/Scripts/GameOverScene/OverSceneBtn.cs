using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverSceneBtn : MonoBehaviour
{
    ScoreCalculator scoreCalculator;
    GameManager gameManager;
    private void Awake()
    {
        scoreCalculator = FindObjectOfType<ScoreCalculator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Retry()
    {
        gameManager.killEnemyNum = 0;
        gameManager.clearWave = 0;
        scoreCalculator.score = 0;
        gameManager.SceneLoad("MainPlay");
    }
    public void GoTitle()
    {
        gameManager.killEnemyNum = 0;
        gameManager.clearWave = 0;
        scoreCalculator.score = 0;
        gameManager.SceneLoad("Title");
    }
}
