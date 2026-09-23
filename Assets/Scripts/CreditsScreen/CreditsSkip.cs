using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSkip : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float normalSpeed = 1f;
    [SerializeField] private float fastSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.speed = fastSpeed;
        }
        else 
        {
            animator.speed = normalSpeed;    
        }
    }
}
