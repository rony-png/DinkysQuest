using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTimer : MonoBehaviour
{
    public float delay = 5f; // The delay before changing scenes
    public string sceneName = "NextScene"; // The name of the scene to load

    private float timer = 0f; // The current timer value

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the delay has been reached
        if (timer >= delay)
        {
            // Load the new scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
