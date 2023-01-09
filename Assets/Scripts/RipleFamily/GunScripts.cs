using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunScripts : MonoBehaviour
{
    
    [SerializeField] private List<AudioClip> audioClipList = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;

    public bool normalState;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    private void OnEnable()
    {
        PlaySound(1);
    }

    public void PlaySound(int soundNum)
    {

        //audioSource.Stop();
        audioSource.clip = audioClipList[soundNum];
        audioSource.Play();
    }

    
}
