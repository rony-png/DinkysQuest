using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCameraOnCollision : MonoBehaviour
{
    public Camera mainCamera;
    public float scaleMultiplier = 2f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.transform.localScale *= scaleMultiplier;
        }
    }
}
