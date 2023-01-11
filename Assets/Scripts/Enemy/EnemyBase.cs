using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public GameObject HPPrefab;
    public Vector3 hpBarOffset = new Vector3(0, 200f, 0);

    public Canvas enemyHpBarCanvas;
    public int numnum;
    
    private void Start()
    {
        
    }

    public void SetHpBar(int num)
    {
        numnum = num;
        Debug.Log(num);
        enemyHpBarCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate(HPPrefab, enemyHpBarCanvas.transform);
        hpBar.name = $"EnmyHpBar(Clone){num}";
        var _hpBar = hpBar.GetComponent<EnemyHP>();
        _hpBar.enemyTransform = this.gameObject.transform;
        num++;
    }

    public virtual void GetDamage(float damageShame)
    {
        
    }    
}
