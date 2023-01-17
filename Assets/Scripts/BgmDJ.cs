using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmDJ : MonoBehaviour
{
    AudioSource mainPlayBgm;
    AudioClip selectClip;
    [SerializeField] private List<AudioClip> rotationClip = new List<AudioClip>();

    [SerializeField] private int num;

    private void Start()
    {
        mainPlayBgm = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(mainPlayBgm.isPlaying == false)
        {
            num++;
            mainPlayBgm.clip = SelectBgm();
            mainPlayBgm.Play();
        }

        if(num == 2)
        {
            num = 0;
        }
    }

    public AudioClip SelectBgm()
    {
        switch (num)
        {
            case 0:
                selectClip = rotationClip[num];
                break;
            case 1:
                selectClip = rotationClip[num];
                break;
            case 2:
                selectClip = rotationClip[num];
                break;
        }
        return selectClip;
    }
}
