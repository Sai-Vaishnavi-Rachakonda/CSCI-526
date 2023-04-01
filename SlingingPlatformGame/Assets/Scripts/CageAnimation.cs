using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageAnimation : MonoBehaviour
{
    private Animator animator;
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

    public void startAnimation()
    {
        animator.SetBool("Open",true);
    }
}
