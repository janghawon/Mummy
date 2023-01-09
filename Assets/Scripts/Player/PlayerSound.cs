using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    public AudioSource playerAudio;
    public List<AudioClip> playerAudioContainer = new List<AudioClip>();
    public bool isActing;
    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    
    public void PlaySound(int soundNum)
    {

        playerAudio.clip = playerAudioContainer[soundNum];
        if(playerAudio.isPlaying == false)
        {
            playerAudio.loop = true;
            playerAudio.Play();
        }
            
    }
    public void EndSound()
    {
        if(playerAudio.isPlaying == true)
        {
            playerAudio.Stop();
        }
        
    }
}
