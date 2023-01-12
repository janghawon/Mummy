using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase
{
    WaveSystem waveSystem;
    public EnemyHP enemyHP;
    bool getBar;
    EnemySpawner enemySpawner;
    PerecentManager percentManager;
    PlayerController player;
    //Transform playerTransform;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        percentManager = FindObjectOfType<PerecentManager>();
        player = FindObjectOfType<PlayerController>();
        waveSystem = FindObjectOfType<WaveSystem>();
        //playerTransform = player.gameObject.GetComponent<Transform>();
    }
    private void Start()
    {
        enemyHP = GameObject.Find($"EnmyHpBar(Clone){enemySpawner.num - 1}").GetComponent<EnemyHP>();
    }

    public override void GetDamage(float damageShame)
    {
        DamageConvey(damageShame);
        percentManager.GetScore(damageShame);
    }
    void DamageConvey(float damageShame)
    {
        getBar = true;
        try
        {
            enemyHP.GetDamage(damageShame);
            if (enemyHP.enemyCurrentHP <= 0)
            {
                waveSystem.enemyCounter.Remove(this.gameObject);
                Destroy(enemyHP.gameObject);
                Destroy(this.gameObject);
            }
        }
        catch
        {
            Debug.Log("�׸���! ���� �̹� �׾���!");
        }
    }

    public override void Walk()
    {
        
        transform.LookAt(player.gameObject.transform.position);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.gameObject.transform.position, 0.005f);
    }
}
