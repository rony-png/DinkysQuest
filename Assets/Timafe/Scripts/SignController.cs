using UnityEngine;

public class SignController : MonoBehaviour
{
    public Canvas signCanvas;

    private void Start()
    {
        signCanvas.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signCanvas.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signCanvas.enabled = false;
        }
    }
}
