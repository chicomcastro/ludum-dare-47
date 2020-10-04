using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = -5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += (new Vector3(speed, 0, 0)) * Time.deltaTime;
    }
}
