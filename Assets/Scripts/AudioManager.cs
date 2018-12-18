using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioLowPassFilter LowPassFilter;
    public AudioSource Victory;
    public AudioSource Drop;
    public AudioSource Collide;
    public AudioSource Reflect;
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        LowPassFilter.cutoffFrequency = 400 + Time.timeScale * 10000;
        Music.Pause();
        Music.Play();
    }
}
