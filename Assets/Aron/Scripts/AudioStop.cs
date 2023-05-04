using UnityEngine;

public class AudioStop : MonoBehaviour
{
    public float stopDelay = 5f; // The time to wait before stopping the audio, in seconds
    public AudioSource audioSource;

    private void Start() => Invoke("StopAudio", stopDelay);

    private void StopAudio() => audioSource.Stop();
}
