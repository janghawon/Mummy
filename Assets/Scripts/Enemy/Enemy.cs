using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase
{
    public EnemyHP enemyHP;
    bool getBar;
    int HPnum;
    private void Awake()
    {
        HPnum = numnum;
    }
    public override void GetDamage(float damageShame)
    {
        
        DamageConvey(damageShame, HPnum);
    }
    void DamageConvey(float damageShame, int HPnum)
    {
        enemyHP = GameObject.Find("UICanvas").transform.Find($"EnmyHpBar(Clone){HPnum}").GetComponent<EnemyHP>();
        getBar = true;
        enemyHP.GetDamage(damageShame);
    }
    private void Update()
    {
      
    }
}
