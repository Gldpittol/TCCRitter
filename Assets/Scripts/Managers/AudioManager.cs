using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audSource;

    private void Awake()
    {
        Instance = this;
        audSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        audSource.PlayOneShot(clip);
    }
}
