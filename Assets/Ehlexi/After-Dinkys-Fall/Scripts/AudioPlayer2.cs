using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer2 : MonoBehaviour
{
    public AudioClip audioClip; // assign the audio clip in the Inspector

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    public void PlayAudio2()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopAudio2()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PauseAudio2()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void ResumeAudio2()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }
}
