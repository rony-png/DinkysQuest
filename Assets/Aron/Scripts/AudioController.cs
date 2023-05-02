using UnityEngine;

public class AudioController : MonoBehaviour
{
    public float firstPauseTime = 5f; // The time to pause the audio for the first time, in seconds
    public float pauseTime = 5f; // The time to pause the audio for, in seconds
    public float disableTime = 10f; // The time to disable the audio after, in seconds

    private AudioSource audioSource;
    private float elapsedTime = 0f;
    private bool isPaused = false;
    private bool isFirstPause = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (isFirstPause)
        {
            if (elapsedTime >= firstPauseTime)
            {
                audioSource.Pause();
                isPaused = true;
                isFirstPause = false;
                elapsedTime = 0f;
            }
        }
        else if (isPaused)
        {
            if (elapsedTime >= pauseTime)
            {
                audioSource.Play();
                isPaused = false;
                elapsedTime = 0f;
            }
        }
        else
        {
            if (elapsedTime >= disableTime)
            {
                audioSource.Stop();
            }
        }
    }
}
