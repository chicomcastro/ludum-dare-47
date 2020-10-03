using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicParameters : MonoBehaviour
{
    public int bpm = 120;

    public static MusicParameters instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }
}
