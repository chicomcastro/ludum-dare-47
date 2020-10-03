using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Music", menuName = "ScriptableObjects/Music", order = 0)]
public class Music : ScriptableObject 
{
    public int bpm = 60;
    public List<Track> tracks;
}