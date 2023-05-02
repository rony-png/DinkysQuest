using UnityEngine;

public class GameOverOnDestroy : MonoBehaviour
{

    public GameObject gameOverScreen;

    void OnDestroy()
    {
        if (gameObject.CompareTag("Player"))
        {
            gameOverScreen.SetActive(true);
        }
    }
}
