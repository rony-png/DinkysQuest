using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeController : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float delayBeforeFadeToBlack = 2.0f;
    public float fadeToBlackDuration = 1.0f;
    public List<GameObject> textObjects;

    private Image fadeImage;
    private bool isFading = false;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(FadeOutText);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(FadeOutText);
    }

    private void FadeOutText()
    {
        if (!isFading)
        {
            isFading = true;
            StartCoroutine(FadeText());
        }
    }

    private IEnumerator FadeText()
    {
        // Fade out all text objects
        foreach (GameObject textObject in textObjects)
        {
            if (textObject != null)
            {
                Text text = textObject.GetComponent<Text>();
                if (text != null)
                {
                    float timeElapsed = 0.0f;
                    while (timeElapsed < fadeDuration)
                    {
                        timeElapsed += Time.deltaTime;
                        float alpha = Mathf.Lerp(1.0f, 0.0f, timeElapsed / fadeDuration);
                        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                        yield return null;
                    }
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
                }
            }
        }

        // Fade to black after a delay
        float delayElapsed = 0.0f;
        while (delayElapsed < delayBeforeFadeToBlack)
        {
            delayElapsed += Time.deltaTime;
            yield return null;
        }

        float fadeElapsed = 0.0f;
        while (fadeElapsed < fadeToBlackDuration)
        {
            fadeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0.0f, 1.0f, fadeElapsed / fadeToBlackDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1.0f);
    }
}
