using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;
    [SerializeField] private GameObject _endingSceneTransition;
    [SerializeField] private float delayTime = 9f;

    private bool endingSceneActivated = false;

    private void Start()
    {
        _startingSceneTransition.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !endingSceneActivated)
        {
            endingSceneActivated = true;
            ActivateEndingSceneTransition();
        }
    }

    private void ActivateEndingSceneTransition()
    {
        _endingSceneTransition.SetActive(true);
        Invoke("LoadNextScene", delayTime);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
