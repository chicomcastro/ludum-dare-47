using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Track", menuName = "ScriptableObjects/Track", order = 1)]
public class Track : ScriptableObject
{
    public string trackName;
    public AudioClip sample;
    public Note[] notes;
}