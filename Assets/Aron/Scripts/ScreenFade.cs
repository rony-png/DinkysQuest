using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image imageToFade; // Reference to the Image component to fade
    public float delayTime = 2f; // Time to wait before starting the fade
    public float fadeTime = 2f; // Time it takes for the image to fade from 0 to 100 opacity

    private float timer = 0f; // Timer used for delaying and fading
    private bool isFading = false; // Flag to indicate whether the fade is currently active

    void Start()
    {
        // Set the alpha value of the image to 0
        Color color = imageToFade.color;
        color.a = 0f;
        imageToFade.color = color;
    }

    void Update()
    {
        if (timer < delayTime)
        {
            // If we haven't waited long enough yet, just update the timer
            timer += Time.deltaTime;
        }
        else if (!isFading)
        {
            // If we have waited long enough and aren't currently fading, start fading the image
            isFading = true;
        }

        if (isFading)
        {
            // Calculate the alpha value to use based on the elapsed time and the fade duration
            float alpha = Mathf.Clamp01((Time.time - (timer + delayTime)) / fadeTime);

            // Update the alpha value of the image color
            Color color = imageToFade.color;
            color.a = alpha;
            imageToFade.color = color;

            // If the fade is complete, set the flag to false to prevent further updates
            if (alpha == 1f)
            {
                isFading = false;
            }
        }
    }
}
