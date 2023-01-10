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

    private void Start()
    {
        SetHpBar();
    }

    private void SetHpBar()
    {
        enemyHpBarCanvas = transform.Find("EnemyHpCanvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(HPPrefab, enemyHpBarCanvas.transform);

        var _hpBar = hpBar.GetComponent<EnemyHP>();
        _hpBar.enemyTransform = this.gameObject.transform;
        
    }

    public virtual void GetDamage(float damageShame)
    {
        
    }    
}
