using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private bool isFading = false;
    private string sceneToLoad = null;

    void Start()
    {
        // Set the alpha value of the fade image to 1 to start with
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;
    }

    public void FadeToScene(string sceneName)
    {
        if (!isFading)
        {
            sceneToLoad = sceneName;
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        isFading = true;

        // Fade out the screen
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
