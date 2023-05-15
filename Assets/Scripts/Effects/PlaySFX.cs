using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    private AudioSource target;

    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    private void Awake()
    {
        target = GetComponent<AudioSource>();
    }

    public void Call()
    {
        target.pitch = Random.Range(minPitch, maxPitch);
        target.Play();
    }
}
