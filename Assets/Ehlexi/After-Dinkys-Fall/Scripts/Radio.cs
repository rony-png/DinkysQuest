using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Radio : MonoBehaviour
{
    public AudioSource audioSource; public AudioClip clip; public float volume = 1.0f; void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.clip = clip; audioSource.volume = volume; audioSource.spatialBlend = 1.0f; 
            // Set to fully 3D sound
            audioSource.Play(); } } void OnTriggerExit2D(Collider2D other) { if (other.CompareTag("Player")) { audioSource.Stop(); 
        }
    } 
}
