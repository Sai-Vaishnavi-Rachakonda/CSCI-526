using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAnimation : MonoBehaviour
{
    private static Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // startAnimation();
        }
    }

    public static void startAnimation()
    {
        animator.SetBool("Open",true);
    }
}
