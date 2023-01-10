using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> SoundContainer = new List<AudioClip>();

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int soundNum)
    {
        audioSource.clip = SoundContainer[soundNum];
        audioSource.Play();
    }
}
