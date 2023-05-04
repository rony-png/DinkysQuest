using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSceneSwitch : MonoBehaviour
{
    private static AudioSceneSwitch instance = null;
    public static AudioSceneSwitch Instance { get { return instance; } }

    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Do nothing here since we want the audio source to keep playing
        // throughout scene switches
    }
}
