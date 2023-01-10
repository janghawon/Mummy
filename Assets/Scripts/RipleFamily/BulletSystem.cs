using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletSystem : MonoBehaviour
{
    AfterImage afterImage;
    LaunchSystem launchSystem;
    GunSoundContainer gun;
    TextMeshProUGUI bulletCountText;
    public int bulletCount;
    bool canAtk;

    private void Awake()
    {
        afterImage = FindObjectOfType<AfterImage>();
        launchSystem = GetComponent<LaunchSystem>();
        bulletCountText = GameObject.Find("BulletCount").GetComponent<TextMeshProUGUI>();
        gun = GetComponent<GunSoundContainer>();
    }
    private void Start()
    {
        canAtk = true;
        bulletCount = 10;
        bulletCountText.text = bulletCount.ToString() + " / 10";
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LaunchBullet();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ReLoad();
        }
    }
    public void LaunchBullet()
    {
        if(bulletCount > 0 && canAtk)
        {
            
            bulletCount--;
            bulletCountText.text = bulletCount.ToString() + " / 10";
            launchSystem.LaunchBullet();
            afterImage.MakeAfterImage();
            gun.PlaySound(0);
            StartCoroutine(AttackCool());
        }
        
    }
    IEnumerator AttackCool()
    {
        canAtk = false;
        yield return new WaitForSeconds(0.5f);
        canAtk = true;
    }
    public void ReLoad()
    {
        StartCoroutine(BulletReLoad());
    }
    IEnumerator BulletReLoad()
    {
        canAtk = false;
        while(bulletCount < 10)
        {
            yield return new WaitForSeconds(0.2f);
            bulletCount++;
            bulletCountText.text = bulletCount.ToString() + " / 10"; 
            //장전소리
            gun.PlaySound(1);
        }
        yield return new WaitForSeconds(1f);
        canAtk = true;
    }
}
