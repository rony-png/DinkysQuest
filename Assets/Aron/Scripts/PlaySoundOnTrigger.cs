using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public AudioClip collisionSound;  // assign the sound clip in the inspector
    private AudioSource audioSource;  // create an AudioSource component

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // add an AudioSource component to the game object
        audioSource.playOnAwake = false;  // do not play the sound automatically
        audioSource.clip = collisionSound;  // assign the sound clip to the AudioSource component
        audioSource.loop = true;  // set the AudioSource component to loop the sound
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerCollider"))  // check for trigger collision with the trigger collider
        {
            audioSource.Play();  // play the looping sound when trigger collision occurs
        }
    }
}
