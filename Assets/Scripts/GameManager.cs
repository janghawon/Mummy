using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.IO;

public class GameManager : MonoBehaviour
{
    

    [Header("±Â±Â")]
    public static GameManager instance;
    public List<GameObject> nextScenePrefab = new List<GameObject>();
    public List<string> sceneList = new List<string>();
    GameObject BlackScreenCanvas;
    GameObject optionCanvas;

    public int killEnemyNum;
    public int clearWave;

    public float effectSoundValue = 0.5f;
    public float bgmSoundValue = 0.5f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        string savePath = Application.dataPath + "/SaveFile.txt";
        if(!File.Exists(savePath))
        {
            File.Create(savePath);
        }
    }

    
    public void SceneProduction(string name)
    {
        switch (name)
        {
            case "next":
                BlackScreenCanvas = Instantiate(nextScenePrefab[0]);
                break;
            case "option":
                optionCanvas = Instantiate(nextScenePrefab[1]);
                break;
            case "help":
                optionCanvas = Instantiate(nextScenePrefab[2]);
                break;


        }
    }
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
