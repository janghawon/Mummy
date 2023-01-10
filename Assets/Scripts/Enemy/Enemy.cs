using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase
{
    public EnemyHP enemyHP;
    bool getBar;
    public override void GetDamage(float damageShame)
    {
        DamageConvey(damageShame);
    }
    void DamageConvey(float damageShame)
    {
        enemyHP = transform.Find("EnemyHpCanvas").Find("EnmyHpBar(Clone)").GetComponent<EnemyHP>();
        getBar = true;
        enemyHP.GetDamage(damageShame);
    }
    private void Update()
    {
      
    }
}
