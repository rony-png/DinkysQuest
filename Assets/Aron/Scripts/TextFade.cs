using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public float fadeRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    //  void Update()
    //  {
    //    if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         StartCoroutine(Fade());
    //    }

    //  }

    IEnumerator Fade()
    {
        while (titleText.alpha > 0)
        {
            yield return new WaitForSeconds(fadeRate);
            titleText.alpha -= .01f;
        }
    }
}