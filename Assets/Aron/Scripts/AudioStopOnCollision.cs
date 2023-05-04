using UnityEngine;

public class AudioStopOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject objectToDetect;
    public GameObject objectToCollideWith;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == objectToCollideWith && collision.otherCollider.gameObject == objectToDetect)
        {
            audioSource.Stop();
        }
    }
}
