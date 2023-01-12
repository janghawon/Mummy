using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase
{
    public EnemyHP enemyHP;
    bool getBar;
    EnemySpawner enemySpawner;
    PerecentManager percentManager;
    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        percentManager = FindObjectOfType<PerecentManager>();
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
                Destroy(enemyHP.gameObject);
                Destroy(this.gameObject);
            }
        }
        catch
        {
            Debug.Log("그만해! 적은 이미 죽었어!");
        }
    }
    private void Update()
    {
      
    }
}
