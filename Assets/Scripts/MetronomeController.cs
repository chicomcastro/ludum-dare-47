using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MetronomeController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip metronomeSample;
    private float lastTime;
    private float beatInterval;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = metronomeSample;
        lastTime = Time.time;
        beatInterval = 60f / MusicPlayer.instance.musicToPlay.bpm;
        InvokeRepeating("CountBeat", beatInterval, beatInterval);
    }

    void CountBeat() {
        audioSource.Play();
    }
}
