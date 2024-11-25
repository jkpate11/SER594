using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    private AudioSource source;
    private Object[] score;

    private void Start()
    {
        score = Resources.LoadAll("SFX/score", typeof(AudioClip));
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var sound = (AudioClip)score[Random.Range(0, score.Length)];
        source.PlayOneShot(sound);
        Destroy(other.gameObject);
    }
}
