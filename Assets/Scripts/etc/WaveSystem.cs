using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    [Header("에너미 생성에 필요한 컴포넌트와 함수들")]
    EnemySpawner enemySpawner;
    public int waveNum;
    public Collider[] serachObject;
    public List<GameObject> enemyCounter = new List<GameObject>();
    public int inMapEnemy;
    public bool turm;

    [Header("웨이브 수를 표시할 컴포넌트와 함수들")]
    TextMeshProUGUI waveText;
    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        waveText = GameObject.Find("WaveText").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        inMapEnemy = 0;
        waveNum = 0;
        turm = true;
        waveText.enabled = false;
    }
    IEnumerator WaveUI()
    {
        waveText.text = "Wave" + waveNum.ToString();
        waveText.enabled = true;
        yield return new WaitForSeconds(1f);
        float fadeCount = 1;
        while(fadeCount > 0)
        {
            fadeCount -= 0.05f;
            waveText.color = new Color(1, 1, 1, fadeCount);
            yield return new WaitForSeconds(0.1f);
        }
        waveText.enabled = false;
        waveText.color = new Color(1, 1, 1, 1);
    }
    private void EnemySpawn()
    {
        int enemyNum = 1;
        if(waveNum < 10)
            enemyNum = waveNum * 2;
        if (waveNum >= 10)
            enemyNum = waveNum + 5;

        enemySpawner.SpawnEnemyBefore(enemyNum);
        
    }
    IEnumerator NumberingEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        serachObject = Physics.OverlapSphere(this.transform.position, 2000f);
        foreach(Collider enemy in serachObject)
        {
            if(enemy.gameObject.GetComponent<EnemyBase>())
            {
                enemyCounter.Add(enemy.gameObject);
                
            }
            
        }
        turm = true;
    }
    private void Update()
    {
        inMapEnemy = enemyCounter.Count;
        if (inMapEnemy == 0 && turm)
        {
            turm = false;
            waveNum++;
            EnemySpawn();
            StartCoroutine(WaveUI());
            StartCoroutine(NumberingEnemy());
            
        }
    }
}
