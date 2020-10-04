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

    private IEnumerator Start()
    {
        beatInterval = 60f / musicToPlay.bpm;
        yield return new WaitForSeconds(beatInterval * 4);

        for (int i = 0; i < musicToPlay.tracks.Count; i++)
        {
            Track track = musicToPlay.tracks[i];
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = track.sample;
            audioSource.playOnAwake = false;
            StartCoroutine(PlayTrack(track, audioSource, i));
        }
    }

    IEnumerator PlayTrack(Track track, AudioSource audioSource, int trackIndex)
    {
        float compassDuration = 4 * beatInterval;
        float[] timeToPlay = track.notes.Select(
            note => (note.tempo + 2 * trackIndex) * beatInterval
        ).ToArray();

        while (true)
        {
            float lastTime = Time.time;
            for (int i = 0; i < track.notes.Length - 1; i++)
            {
                Note note = track.notes[i];
                audioSource.pitch = Mathf.Pow(2, note.pitch / 12.0f);
                audioSource.Play();
                yield return new WaitUntil(() => Time.time >= lastTime + timeToPlay[i]);
            }
        }
    }
}
