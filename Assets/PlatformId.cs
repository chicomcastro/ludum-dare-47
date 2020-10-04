using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformId : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other) {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();

        // TODO See player
        // TODO Count score
    }
}
