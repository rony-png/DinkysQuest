using UnityEngine;
using UnityEngine.Video;

public class CutsceneTrigger : MonoBehaviour
{
    public VideoClip cutsceneClip; // The video clip to play
    public bool playOnAwake = true; // Whether to start playing the clip automatically when the scene starts
    public bool destroyOnFinish = true; // Whether to destroy this game object when the clip finishes playing

    private VideoPlayer videoPlayer; // The VideoPlayer component used to play the clip

    private void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>(); // Add a VideoPlayer component to this game object
        videoPlayer.clip = cutsceneClip; // Set the video clip to play

        if (playOnAwake)
        {
            PlayCutscene(); // Start playing the clip automatically
        }
    }

    public void PlayCutscene()
    {
        Time.timeScale = 0f; // Freeze the game
        videoPlayer.Play(); // Play the clip
        videoPlayer.loopPointReached += OnCutsceneFinished; // Set up a callback for when the clip finishes playing
    }

    private void OnCutsceneFinished(VideoPlayer player)
    {
        Time.timeScale = 1f; // Unfreeze the game
        if (destroyOnFinish)
        {
            Destroy(gameObject); // Destroy this game object if destroyOnFinish is true
        }
    }
}