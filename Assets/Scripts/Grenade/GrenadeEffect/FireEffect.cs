using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    AudioSource audioSource;
    ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
        audioSource.Play();
        Destroy(this.gameObject, 6f);
        //StartCoroutine(FadeOut());
    }
   
    
    
}
