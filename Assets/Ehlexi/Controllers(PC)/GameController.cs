using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    int Dinks = 0;
    public void GameOver()
    {
        GameOverScreen.Setup(Dinks);
    }
    private void Awake()
    {
        
    }
}
