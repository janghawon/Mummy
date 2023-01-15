using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> nextScenePrefab = new List<GameObject>();
    public List<string> sceneList = new List<string>();
    GameObject BlackScreenCanvas;
    GameObject optionCanvas;

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
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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


        }
    }
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
