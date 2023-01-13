using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateTimer : MonoBehaviour
{
    Slider ultimateTimer;
    Image screenEffect;
    UltimateSkill ultimateSkill;
    public float time;
    public bool one;
    private void Awake()
    {
        ultimateTimer = GetComponent<Slider>();
        screenEffect = GetComponentInParent<Image>();
        ultimateSkill = FindObjectOfType<UltimateSkill>();
    }
    private void Start()
    {
        one = true;
    }
    public void StartTimer()
    {
        StartCoroutine(UltimateTimerStrt());
    }

    private void Update()
    {
        if(ultimateSkill.isUltimate)
        {
            time += Time.deltaTime;
            ultimateTimer.value = (10 - time) / 10;
            
        }
        else
        {
            time = 0;
            
        }

        if (ultimateTimer.value <= 0 && one)
        {
            
            ultimateSkill.isUltimate = false;
            one = false;
            ultimateSkill.OffUltimateSkill();
            Debug.Log(ultimateTimer.value);
            
        }

    }
    IEnumerator UltimateTimerStrt()
    {
        yield return null;
    }
}
