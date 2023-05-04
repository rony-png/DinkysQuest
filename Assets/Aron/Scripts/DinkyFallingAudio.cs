using UnityEngine;

public class DinkyFallingAudio : MonoBehaviour
{
    public float playDelay = 5f; // The time to wait before playing the audio, in seconds
    public AudioSource audioSource;

    private float elapsedTime = 0f;
    private bool hasPlayed = false;

    private void Update()
    {
        if (!hasPlayed)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= playDelay)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
    }
}
