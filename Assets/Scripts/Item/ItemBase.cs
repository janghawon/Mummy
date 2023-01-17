using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ItemBase : MonoBehaviour
{
    public PlayerHP playerHP;
    public LaunchSystem riple;
    public GameObject player;
    private void Awake()
    {
        playerHP = FindObjectOfType<PlayerHP>();
        riple = FindObjectOfType<LaunchSystem>();
        player = playerHP.gameObject;
    }
    private void Start()
    {
        Rotate();
        Destroy(this.gameObject, 10f);
    }
    void Rotate()
    {
        transform.DORotate(new Vector3(-90, 180, 0), 2).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GiveEffect();
            Destroy(this.gameObject);
        }
    }

    public virtual void GiveEffect()
    {
        
    }
}
