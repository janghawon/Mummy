using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class SettingButtonInner : MonoBehaviour
{
    GameManager gameManager;
    Slider effectVolumeSlider;
    Slider bgmVolumeSlider;

    AudioSource[] mapAudio;
    AudioSource[] effectAudios;
    AudioSource[] bgmAidios;

    AudioSource targetEffect;
    AudioSource targetBGM;

    RotationMouse mouseControll;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        effectVolumeSlider = GameObject.Find("EffectSoundSlider").GetComponent<Slider>();
        bgmVolumeSlider = GameObject.Find("BGMSoundSlider").GetComponent<Slider>();

        mapAudio = FindObjectsOfType<AudioSource>();

        effectAudios = mapAudio.Where(x => x.loop == false).ToArray();
        bgmAidios = mapAudio.Where(x => x.bypassReverbZones == true).ToArray();

        try
        {
            effectVolumeSlider.value = effectAudios[0].volume;
            bgmVolumeSlider.value = bgmAidios[0].volume;
        }
        catch
        {
            Debug.Log("¾ÆÁ÷ ¼ÂÆÃ ¾ÈÇÔ");
        }

        mouseControll = FindObjectOfType<RotationMouse>();
        try
        {
            mouseControll.canRotationMouse = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        catch
        {
            Debug.Log("¸ÞÀÎÇÃ·¹ÀÌ ¾À ¾Æ´Ô");
        }

        StartCoroutine(TickTok());
    }
    IEnumerator TickTok()
    {
        try
        {
            foreach (AudioSource targetEffect in effectAudios)
            {
                targetEffect.volume = effectVolumeSlider.value;
            }
            foreach (AudioSource targetBGM in bgmAidios)
            {
                targetBGM.volume = bgmVolumeSlider.value;
            }
        }
        catch
        {
            Debug.Log("Èþ");
        }

        yield return new WaitForSeconds(0.3f);
        StartCoroutine(TickTok());
    }

    public void ExitSetting()
    {
        GameObject SettingCanvas = GameObject.Find("SettingCanvas(Clone)");

        MainOptionManager mainOptionManager;
        mainOptionManager = FindObjectOfType<MainOptionManager>();
        
        try
        {
            mainOptionManager.canOpenPannel = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        catch
        {
            Debug.Log("¸ÞÀÎ ÇÃ·¹ÀÌ ¾À ¾Æ´Ô");
        }
        try
        {
            mouseControll.canRotationMouse = true;
        }
        catch
        {
            Debug.Log("¸ÞÀÎÇÃ·¹ÀÌ ¾À ¾Æ´Ô");
        }
        Destroy(SettingCanvas);
    }
}
