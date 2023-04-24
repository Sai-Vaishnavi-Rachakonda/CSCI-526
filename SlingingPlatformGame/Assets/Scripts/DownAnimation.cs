using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAnimation : MonoBehaviour
{
    private static Animator animator;
    public GameObject cage;
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collided = true;
        Debug.Log("Here123"+ collision.gameObject.tag);
        if (collision.gameObject.CompareTag("bomb"))
        {
            startAnimation();
            cage.GetComponent<CageAnimation>().startAnimation();
        }

    }
}
