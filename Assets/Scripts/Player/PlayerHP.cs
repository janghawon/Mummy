using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider playerHpBar;
    public float playerCurrentHP;
    public float playerMaxHp;
    public bool isAlive;
    private void Awake()
    {
        playerHpBar = GameObject.Find("PlayerHpSlider").GetComponent<Slider>();
    }
    private void Start()
    {
        isAlive = true;
        playerCurrentHP = playerMaxHp;
    }

    public void GetDamage(float damageShame)
    {
        if(isAlive)
            playerCurrentHP -= damageShame;

        if(playerCurrentHP > 0)
        {
            isAlive = true;
        }
        else if(playerCurrentHP <= 0)
        {
            isAlive = false;
        }
    }
    private void CalHp()
    {
        playerHpBar.value = Mathf.Lerp(playerHpBar.value, playerCurrentHP / playerMaxHp, Time.deltaTime * 10);
    }
    private void Update()
    {
        CalHp();
        if(Input.GetKeyDown(KeyCode.V))
        {
            GetDamage(10);
        }
    }
}
