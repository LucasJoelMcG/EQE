using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsSkip : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image skipButtonImage;

    [SerializeField] private float normalSpeed = 1f;
    [SerializeField] private float fastSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.speed = fastSpeed;
            audioSource.pitch = fastSpeed;

            skipButtonImage.enabled = false;
        }
        else 
        {
            animator.speed = normalSpeed;
            audioSource.pitch = normalSpeed;

            skipButtonImage.enabled = true;
        }
    }
}
