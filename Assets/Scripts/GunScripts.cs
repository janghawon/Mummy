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
        PlaySound(audioClipList[1]);
    }

    private void PlaySound(AudioClip sound)
    {
        audioSource.Stop();
        audioSource.clip = sound;
        audioSource.Play();
    }

    
}
