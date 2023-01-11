using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    private Camera uiCamera;
    private Canvas canvas;
    private RectTransform rectParent;
    private RectTransform rectHP;

    public Transform enemyTransform;

    public Slider enemyHpBar;
    public float enemyCurrentHP;
    public float enemyMaxHP;
    public bool isAlive;
    private void Awake()
    {
        canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHP = this.gameObject.GetComponent<RectTransform>();
        enemyHpBar = GetComponent<Slider>();
    }
    private void Start()
    {
        isAlive = true;
        enemyCurrentHP = enemyMaxHP;
        enemyHpBar.value = 1;
    }
    private void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(enemyTransform.position + new Vector3(0, 2, 0));
        if(screenPos.z < 0f)
        {
            screenPos *= -1f;
        }
        var localPos = new Vector2(0, 20);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, uiCamera, out localPos);
        rectHP.localPosition = localPos;
    }

    public void GetDamage(float damageShame)
    {
        Debug.Log(damageShame);
        if(isAlive)
            enemyCurrentHP -= damageShame;

        if (enemyCurrentHP > 0)
        {
            isAlive = true;
        }
        else if (enemyCurrentHP <= 0)
        {
            
            isAlive = false;
            
        }
    }
    private void CalHp()
    {
        enemyHpBar.value = Mathf.Lerp(enemyHpBar.value, enemyCurrentHP / enemyMaxHP, Time.deltaTime * 10);
    }
    private void Update()
    {
        CalHp();
        
    }
}
