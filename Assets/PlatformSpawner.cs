using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformObj;
    public Transform platformParent;
    public float platHorDist;
    public float platVertDist;

    public float x0, y0;

    // Start is called before the first frame update
    void Start()
    {
        List<Color> colors = new List<Color> {Color.blue, Color.red, Color.green};
        for (int i = 0; i < MusicPlayer.instance.musicToPlay.tracks.Count; i++)
        {
            Track track = MusicPlayer.instance.musicToPlay.tracks[i];
            for (int j = 0; j < track.notes.Length; j++)
            {
                for (int k = i; k < MusicPlayer.instance.musicToPlay.tracks.Count; k++)
                {
                    Note note = track.notes[j];
                    GameObject gamo = Instantiate(
                        platformObj,    
                        new Vector3(
                            x0 + k * platHorDist * 8 + platHorDist * note.tempo,
                            y0 + platVertDist * i,
                            0
                        ),
                        Quaternion.identity,
                        platformParent
                    );
                    gamo.GetComponent<SpriteRenderer>().color = colors[i];
                    AudioSource audioSource = gamo.AddComponent<AudioSource>();
                    audioSource.clip = track.sample;
                    audioSource.pitch = Mathf.Pow(2, note.pitch / 12.0f);                    
                }
            }
        }
    }
}
