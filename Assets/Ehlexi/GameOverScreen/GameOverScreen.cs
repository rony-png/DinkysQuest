using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public Text DinksText;
  public void Setup (int Dinks)
    {
        gameObject.SetActive(true);
        DinksText.text = Dinks.ToString() + " Dinks =";
    }
}
