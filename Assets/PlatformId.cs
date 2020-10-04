using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformId : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isScorable;

    private bool masterIsOnMe;
    private bool haveScored;
    private float masterHitTime;

    private void Start() {
        masterIsOnMe = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "MasterCounter") {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            masterIsOnMe = true;
            masterHitTime = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {        
        // See player
        if (other.tag == "PlayerTrigger" && masterIsOnMe && !haveScored && isScorable) {
            GameObject player = other.GetComponent<Collider2D>().transform.parent.gameObject;

            // Do not score for above positioning
            if (player.transform.position.y < transform.position.y) {
                return;
            }

            float playerHitTime = Time.time;
            ScoreManager.instance.CountScore(Mathf.Abs(playerHitTime - masterHitTime));

            // TODO Count score
            haveScored = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "MasterCounter") {
            masterIsOnMe = false;

            if (!haveScored) {
                // TODO send to black list
            }
        }
    }
}
