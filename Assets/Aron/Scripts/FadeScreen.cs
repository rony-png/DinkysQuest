using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Image imageToFade; // Reference to the Image component to fade
    public float fadeTime = 2f; // Time it takes for the image to fade from 100 to 0 alpha

    private float timer = 0f; // Timer used for fading

    void Start()
    {
        // Start the timer for the fade
        timer = Time.time;

        // Set the alpha value of the image to 1
        Color color = imageToFade.color;
        color.a = 1f;
        imageToFade.color = color;
    }

    void Update()
    {
        // Calculate the alpha value to use based on the elapsed time and the fade duration
        float alpha = 1f - Mathf.Clamp01((Time.time - timer) / fadeTime);

        // Update the alpha value of the image color
        Color color = imageToFade.color;
        color.a = alpha;
        imageToFade.color = color;

        // If the fade is complete, destroy the game object
        if (alpha == 0f)
        {
            Destroy(gameObject);
        }
    }
}