using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;



[System.Serializable]
public class BestScoreData
{
    public float bestScore;
}

public class ScoreCalculator : MonoBehaviour
{
    [Header("제이슨 작업")]
    public float score;
    public BestScoreData bestScoreData;
    string savePath;
    string saveFileName = "/SaveFile.txt";
    

    [Header("텍스트 컴포넌트")]
    TextMeshProUGUI scoreText;
    TextMeshProUGUI bestScoreText;
    TextMeshProUGUI waveText;
    TextMeshProUGUI killEnemyText;
    public bool startCal;
    
    GameManager gameManager;
    OverSceneBtn btnGroup;
    Rank rankSystem;
    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = GameObject.Find("BestScorText").GetComponent<TextMeshProUGUI>();
        btnGroup = FindObjectOfType<OverSceneBtn>();
        waveText = GameObject.Find("WaveText").GetComponent<TextMeshProUGUI>();
        killEnemyText = GameObject.Find("KillEnemyText").GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
        rankSystem = FindObjectOfType<Rank>();
    }
    void Start()
    {
        bestScoreData = new BestScoreData();
        savePath = Application.dataPath + saveFileName;

        StartCoroutine(GetRandom());
        StartCoroutine(EndRandom());
    }
    IEnumerator EndRandom()
    {
        
        yield return new WaitForSeconds(3f);
        startCal = true;
        yield return new WaitForSeconds(0.05f);
        scoreText.text = "Score : " + CalScore();
        waveText.text = "Clear Wave : ";//+ gameManager.clearWave.ToString();
        killEnemyText.text = "Kill Enemy : ";// + gameManager.killEnemyNum.ToString();

        string loadjson = File.ReadAllText(savePath);
        bestScoreData = JsonUtility.FromJson<BestScoreData>(loadjson);

        bestScoreText.text = "BestScore : " + bestScoreData.bestScore;

        yield return new WaitForSeconds(0.5f);
        rankSystem.RateRankSystem(1);//gameManager.killEnemyNum);

        yield return new WaitForSeconds(0.5f);
        btnGroup.gameObject.SetActive(true);
;   }
    public float CalScore()
    {
        try
        {
            score = (gameManager.clearWave * gameManager.killEnemyNum) * 100;
            if (score > bestScoreData.bestScore)
            {
                bestScoreData.bestScore = score;
                string json = JsonUtility.ToJson(bestScoreData);
                File.WriteAllText(savePath, json);

                Debug.Log(bestScoreData.bestScore);
            }
        }
        catch
        {
            Debug.Log("점수 계산 실패");
        }
        return score;
    }

    IEnumerator GetRandom()
    {
        while(!startCal)
        {
            int ran1 = Random.Range(1, 10);
            int ran2 = Random.Range(1, 10);
            int ran3 = Random.Range(1, 10);
            int ran4 = Random.Range(1, 10);

            waveText.text = "Clear Wave : " + RandomText(ran1);
            killEnemyText.text = "Kill Enemy : " + RandomText(ran2);
            scoreText.text = "Score : " + RandomText(ran3);
            bestScoreText.text = "Best Score : " + RandomText(ran4);
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    public string RandomText(int num)
    {
        string str = "";
        switch (num)
        {
            case 1:
                str = "45";
                break;
            case 2:
                str = "4348";
                break;
            case 3:
                str = "320";
                break;
            case 4:
                str = "2902";
                break;
            case 5:
                str = "2904";
                break;
            case 6:
                str = "230";
                break;
            case 7:
                str = "109";
                break;
            case 8:
                str = "34980";
                break;
            case 9:
                str = "190";
                break;
            case 10:
                str = "7900";
                break;
        }
        return str;
        
    }
}
