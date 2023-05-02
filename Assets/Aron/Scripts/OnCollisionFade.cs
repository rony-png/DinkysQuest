using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OnCollisionFade : MonoBehaviour
{
    public float fadeSpeed = 1f;
    public Image fadeImage;

    private bool isFading = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle" && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeToBlack());
        }
    }

    private IEnumerator FadeToBlack()
    {
        Color currentColor = fadeImage.color;
        while (fadeImage.color.a < 1f)
        {
            float newAlpha = currentColor.a + (fadeSpeed * Time.deltaTime);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            yield return null;
        }
    }
}
