using System;
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
    PlayerHP playerHP;
    public bool canAtk;
    ItemSystem itemSystem;
    GameManager gm;
    //Transform playerTransform;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        percentManager = FindObjectOfType<PerecentManager>();
        player = FindObjectOfType<PlayerController>();
        waveSystem = FindObjectOfType<WaveSystem>();
        playerHP = FindObjectOfType<PlayerHP>();
        itemSystem = FindObjectOfType<ItemSystem>();
        gm = FindObjectOfType<GameManager>();
        //playerTransform = player.gameObject.GetComponent<Transform>();
    }
    private void Start()
    {
        enemyHP = GameObject.Find($"EnmyHpBar(Clone){enemySpawner.num - 1}").GetComponent<EnemyHP>();
        canAtk = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack());
        }
        
    }

    IEnumerator Attack()
    {
        if(canAtk)
        {
            canAtk = false;
            playerHP.playerCurrentHP -= 5;
            yield return new WaitForSeconds(2f);
            canAtk = true;
        }
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
                gm.killEnemyNum++;

                waveSystem.enemyCounter.Remove(this.gameObject);

                GameObject dropItem = Instantiate(itemSystem.DropItem());
                dropItem.transform.position = this.gameObject.transform.position;

                Destroy(enemyHP.gameObject);
                Destroy(this.gameObject);
            }
        }
        catch
        {
            Debug.Log("그만해! 적은 이미 죽었어!");
        }
    }

    public override void Walk()
    {
        
        transform.LookAt(player.gameObject.transform.position);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.gameObject.transform.position, 0.003f);
    }
}
