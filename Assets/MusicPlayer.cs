using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    public Music musicToPlay;

    private float beatInterval;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        beatInterval = 60f / musicToPlay.bpm;

        foreach (Track track in musicToPlay.tracks)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = track.sample;
            audioSource.playOnAwake = false;
            StartCoroutine(PlayTrack(track, audioSource));
        }
    }

    IEnumerator PlayTrack(Track track, AudioSource audioSource)
    {
        float[] waitingIntervals = track.notes.Zip(
            track.notes.Skip(1), (x, y) => (y.tempo - x.tempo) * beatInterval
        ).ToArray<float>();
        print(string.Join(" ,", waitingIntervals.Select(i => i.ToString()).ToArray()));

        while (true)
        {
            for (int i = 0; i < track.notes.Length - 1; i++)
            {
                audioSource.Play();
                yield return new WaitForSeconds(waitingIntervals[i]);
            }
            audioSource.Play();

            float compassDuration = 4 * beatInterval;
            float remainingTime = compassDuration - waitingIntervals.Sum() % (compassDuration);
            yield return new WaitForSeconds(remainingTime);
        }
    }
}
