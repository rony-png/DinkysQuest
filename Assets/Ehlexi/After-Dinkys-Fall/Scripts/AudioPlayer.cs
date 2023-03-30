using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip1; // assign the first audio clip in the Inspector
    public AudioClip audioClip2; // assign the second audio clip in the Inspector

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        PlayAudio();
    }

    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PauseAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void ResumeAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }

    public void PlayAudio2()
    {
        StopAudio();
        audioSource.clip = audioClip2;
        PlayAudio();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayAudio2();
        }
    }
}

