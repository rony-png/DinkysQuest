using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinkysDemise : MonoBehaviour
{
    public float timeToPlayAnimation = 5f; // Amount of time to wait before playing animation
    public AnimationClip idleAnimation; // Idle animation to play while waiting
    public AnimationClip playAnimation; // Animation to play after waiting

    private Animator animator;
    private bool hasPlayedAnimation = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(idleAnimation.name);
        StartCoroutine(PlayAnimationAfterTime());
    }

    IEnumerator PlayAnimationAfterTime()
    {
        yield return new WaitForSeconds(timeToPlayAnimation);
        if (!hasPlayedAnimation)
        {
            animator.Play(playAnimation.name);
            hasPlayedAnimation = true;
        }
    }
}
